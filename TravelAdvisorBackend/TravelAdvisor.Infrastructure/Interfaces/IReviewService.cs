using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetById(Guid id);

        Task<ReviewDto> GetAll();

        Task<List<ReviewDto>> GetList();

        Task<bool> Delete(Guid id);

        Task<Guid> Create(ReviewCreateDto newReview);

        Task<bool> Update(ReviewUpdateDto updateReview);
    }
}
