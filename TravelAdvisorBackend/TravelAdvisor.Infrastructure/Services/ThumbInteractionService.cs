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
    public class ThumbInteractionService : IThumbInteractionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ThumbInteractionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Create(ThumbInteractionCreateDto newThumbInteraction)
        {
            if (newThumbInteraction == null) throw new NullReferenceException(nameof(newThumbInteraction));

            var mappedThumbInteraction = _mapper.Map<ThumbInteraction>(newThumbInteraction);
            mappedThumbInteraction.Review = await _unitOfWork.ReviewRepository.GetByGuidAsync(newThumbInteraction.ReviewId);
            mappedThumbInteraction.User = await _unitOfWork.UserRepository.GetByGuidAsync(newThumbInteraction.UserId);

            var review = await _unitOfWork.ReviewRepository.GetByGuidAsync(newThumbInteraction.ReviewId);

            if (newThumbInteraction.HasLiked) review.Likes++;
            else review.Dislikes++;

            await _unitOfWork.ReviewRepository.UpdateAsync(review);
            await _unitOfWork.ThumbInteractionRepository.AddAsync(mappedThumbInteraction);
            await _unitOfWork.SaveChanges();

            return mappedThumbInteraction.Id;
        }

        public async Task<bool> Update(ThumbInteractionUpdateDto updateThumbInteraction)
        {
            var thumbInteraction = await _unitOfWork.ThumbInteractionRepository.GetByGuidAsync(updateThumbInteraction.Id);

            if (updateThumbInteraction.HasLiked && thumbInteraction.HasLiked)
            {
                var updateReview = await _unitOfWork.ReviewRepository.GetByGuidAsync(updateThumbInteraction.ReviewId);

                if (updateThumbInteraction.HasLiked) updateReview.Likes--;
                
                else updateReview.Dislikes--;
                
                await Delete(updateThumbInteraction.Id);
                return true; // fixa
            }
            else if (updateThumbInteraction.HasLiked != thumbInteraction.HasLiked)
            {
                thumbInteraction.HasLiked = !thumbInteraction.HasLiked;
                var updateReview = await _unitOfWork.ReviewRepository.GetByGuidAsync(updateThumbInteraction.ReviewId);

                if (thumbInteraction.HasLiked) { updateReview.Likes++; updateReview.Dislikes--; }
                else { updateReview.Likes--; updateReview.Dislikes++; }

                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Guid thumbInteractionId)
        {
            var thumbInteraction = await _unitOfWork.ThumbInteractionRepository.GetByGuidAsync(thumbInteractionId);

            if (thumbInteraction != null)
            {
                await _unitOfWork.ThumbInteractionRepository.RemoveAsync(thumbInteraction);
                await _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public Task<ThumbInteractionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ThumbInteractionDto>> GetById(Guid id)
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

        public Task<List<ThumbInteractionDto>> GetList()
        {
            throw new NotImplementedException();
        }

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
    }
}
