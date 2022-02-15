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
        //Varför retunera objektet?
        //Fixa resten!
        public async Task<Guid> Create(ThumbInteractionCreateDto newThumbInteraction)
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
                return createdThumbInteraction.Id;
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
            return response.Id;
        }
        public Task<bool> Update(ThumbInteractionUpdateDto thumbInteractionUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
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
