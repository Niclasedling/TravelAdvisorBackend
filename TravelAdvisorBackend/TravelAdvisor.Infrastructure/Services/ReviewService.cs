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

            map.Attraction= await _unitOfWork.AttractionRepository.GetByGuidAsync(newReview.AttractionId); 
            map.User = await _unitOfWork.UserRepository.GetByGuidAsync(newReview.UserId);


            var createdReview = await _unitOfWork.ReviewRepository.AddAsync(map);

            if (createdReview is null)
            {
                throw new Exception();
            }
            
            
            await _unitOfWork.SaveChanges();

            return createdReview.Id;
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

        public async Task<ReviewDto> GetAll()
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllAsync();

            if (reviews != null)
            {
                return _mapper.Map<ReviewDto>(reviews);
            }

            return null; //Lägg till felmeddelande
        }

        public async Task<ReviewDto> GetById(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByGuidAsync(id);

            if (review != null)
            {
                return _mapper.Map<ReviewDto>(review);
            }

            return null; //Lägg till felmeddelande.
        }

        public async Task<List<ReviewDto>> GetList()
        {


            var reviews = await _unitOfWork.ReviewRepository.ListAsync(
                x => x,
               include: i => i
              .Include(x => x.User)
              .Include(x => x.Attraction)
 
               ); 


            if (reviews != null)
            {
                return _mapper.Map<List<ReviewDto>>(reviews);
            }

            return null; //Lägg till felmeddelande
    

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
