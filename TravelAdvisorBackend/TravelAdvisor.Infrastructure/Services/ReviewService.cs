using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Create(ReviewCreateDto newReview)
        {

            if (newReview == null) throw new NullReferenceException(nameof(newReview));

            var map = _mapper.Map<Review>(newReview);

            map.Attraction = await _unitOfWork.AttractionRepository.GetByGuidAsync(newReview.AttractionId);
            map.User = await _unitOfWork.UserRepository.GetByGuidAsync(newReview.UserId);       

            var createdReview = await _unitOfWork.ReviewRepository.AddAsync(map);

            if (createdReview is null)
            {
                throw new Exception();
            }
                    
            await _unitOfWork.SaveChanges();

            return createdReview.Id;
        }
        public async Task<Guid> CreateComment(CommentCreateDto newComment)
        {
            if (newComment == null) throw new NullReferenceException(nameof(newComment));

            var mappedComment = _mapper.Map<Comment>(newComment);

            mappedComment.Review = await _unitOfWork.ReviewRepository.GetByGuidAsync(newComment.ReviewId);
            mappedComment.User = await _unitOfWork.UserRepository.GetByGuidAsync(newComment.UserId);

            var createdComment = await _unitOfWork.CommentRepository.AddAsync(mappedComment);

            if (createdComment != null)
            {
                await _unitOfWork.SaveChanges();
                return createdComment.Id;
            }
            else
            {
                throw new Exception();
            }
        }
        public async Task<ThumbInteractionDto> CreateThumbInteraction(ThumbInteractionCreateDto newThumbInteraction)
        {
            if (newThumbInteraction == null) throw new NullReferenceException(nameof(newThumbInteraction));
            
            var mappedThumbInteraction = _mapper.Map<ThumbInteraction>(newThumbInteraction);
            mappedThumbInteraction.Review = await _unitOfWork.ReviewRepository.GetByGuidAsync(newThumbInteraction.ReviewId);
            mappedThumbInteraction.User = await _unitOfWork.UserRepository.GetByGuidAsync(newThumbInteraction.UserId);

            var response = await CheckThumbInteraction(newThumbInteraction.UserId);

            if (response == null)
            {
                var updateReview = await _unitOfWork.ReviewRepository.GetByGuidAsync(mappedThumbInteraction.Review.Id);

                if (mappedThumbInteraction.HasLiked)
                {
                    updateReview.Likes++;
                }
                else
                {
                    updateReview.Dislikes++;
                }

                await _unitOfWork.ReviewRepository.UpdateAsync(updateReview);
                var createdThumbInteraction = await _unitOfWork.ThumbInteractionRepository.AddAsync(mappedThumbInteraction);

                await _unitOfWork.SaveChanges();
                return _mapper.Map<ThumbInteractionDto>(createdThumbInteraction);
            }
            else
            {
                if (response.HasLiked == newThumbInteraction.HasLiked)
                {
                    var updateReview = await _unitOfWork.ReviewRepository.GetByGuidAsync(mappedThumbInteraction.Review.Id);
                    mappedThumbInteraction.Review = null;
                    mappedThumbInteraction.User = null;

                    await _unitOfWork.ThumbInteractionRepository.UpdateAsync(mappedThumbInteraction);

                    await _unitOfWork.ThumbInteractionRepository.RemoveAsync(mappedThumbInteraction);


                    if (response.HasLiked)
                    {
                        updateReview.Likes--;
                    }
                    else
                    {
                        updateReview.Dislikes--;
                    }

                    await _unitOfWork.ReviewRepository.UpdateAsync(updateReview);
                }
                else if (response.HasLiked != newThumbInteraction.HasLiked)
                {
                    var thumbInteraction = await _unitOfWork.ThumbInteractionRepository.GetByGuidAsync(response.Id);
                    thumbInteraction.HasLiked = !thumbInteraction.HasLiked;

                    var updateReview = await _unitOfWork.ReviewRepository.GetByGuidAsync(mappedThumbInteraction.Review.Id);

                    if (thumbInteraction.HasLiked)
                    {
                        updateReview.Likes++;
                        updateReview.Dislikes--;
                    }
                    else
                    {
                        updateReview.Likes--;
                        updateReview.Dislikes++;
                    }

                    await _unitOfWork.ReviewRepository.UpdateAsync(updateReview);
                }
            }

            await _unitOfWork.SaveChanges();
            return _mapper.Map<ThumbInteractionDto>(response);
        }
        //public async Task<ThumbInteractionDto> UpdateThumbInteraction(ThumbInteractionCreateDto newThumbInteraction)
        //{

        //}
        //{

        //}
        //public async Task<ThumbInteractionDto> DeleteThumbInteraction(Guid thumbInteractionId)
        //{

        //}

        public async Task<ThumbInteractionDto> CheckThumbInteraction(Guid userId)
        {
            var thumbInteraction = await _unitOfWork.ThumbInteractionRepository.GetByGuidAsync(
                x => x,
                predicate: x => x.User.Id == userId,
                null);

            if (thumbInteraction != null)
            {
                return _mapper.Map<ThumbInteractionDto>(thumbInteraction.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByGuidAsync(id);
            bool success = false;

            if (review != null)
            {
                await _unitOfWork.ReviewRepository.RemoveAsync(review);
                await _unitOfWork.SaveChanges();
                success = true;

            }
            return success;
        }

        public async Task<List<ReviewDto>> GetAll()
        {
            var reviews = await _unitOfWork.ReviewRepository.ListAsync(
                x => x,
                include: i => i
                .Include(x => x.Attraction)
                .Include(x => x.User)

                );

            if (reviews != null)
            {
                return _mapper.Map<List<ReviewDto>>(reviews);
            }

            return null; 
        }

        public async Task<ReviewDto> GetById(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByGuidAsync(id);

            if (review != null)
            {
                var map = _mapper.Map<ReviewDto>(review);
                return map;
            }

            return null;
        }

        public async Task<List<ReviewDto>> GetListById(Guid id)
        {

            var reviews = await _unitOfWork.ReviewRepository.ListAsync(
               x => x,
               predicate: x => x.Attraction.Id == id,
               include: i => i
              .Include(x => x.User)
              .Include(x => x.Attraction));

            if (reviews != null)
            {
                var map =  _mapper.Map<List<ReviewDto>>(reviews);
                return map;
            }

            return null; 
        }

        public async Task<List<CommentDto>> GetCommentsByReviewId(Guid id)
        {
            var comments = await _unitOfWork.CommentRepository.ListAsync(
                x => x,
                predicate: x => x.Review.Id == id,
                include: i => i
                .Include(x => x.User)
                .Include(x => x.Review));


            if (comments != null)
            {
                var mappedComments = _mapper.Map<List<CommentDto>>(comments);
                return mappedComments;
            }

            return null;
        }

        public async Task<List<ThumbInteractionDto>> GetThumbInteractionsByReviewId(Guid id)
        {
            var thumbInteractions = await _unitOfWork.ThumbInteractionRepository.ListAsync(
                x => x,
                predicate: x => x.Review.Id == id,
                include: i => i
                .Include(x => x.User)
                .Include(x => x.Review));

            if (thumbInteractions != null)
            {
                var mappedThumbInteractions = _mapper.Map<List<ThumbInteractionDto>>(thumbInteractions);
                return mappedThumbInteractions;
            }
            return null;
        }

        public async Task<bool> Update(ReviewUpdateDto updateReview)
        {
            if (updateReview == null) throw new ArgumentNullException(nameof(updateReview));

            await _unitOfWork.ReviewRepository.UpdateAsync(_mapper.Map<Review>(updateReview));

            await _unitOfWork.SaveChanges();

            var dbReview = _mapper.Map<ReviewUpdateDto>(await _unitOfWork.ReviewRepository.GetByGuidAsync(updateReview.Id));

            if (dbReview == updateReview) return true;

            else return false;
        }

    }
}
