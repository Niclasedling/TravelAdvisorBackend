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

        Task<List<ReviewDto>> GetAll();

        Task<List<ReviewDto>> GetListById(Guid id);

        Task<List<CommentDto>> GetCommentsByReviewId(Guid id);

        Task<List<ThumbInteractionDto>> GetThumbInteractionsByReviewId(Guid id);

        Task<bool> Delete(Guid id);

        Task<bool> DeleteThumbInteraction(Guid thumbInteractionId);

        Task<Guid> Create(ReviewCreateDto newReview);

        Task<Guid> CreateComment(CommentCreateDto newComment);

        Task<ThumbInteractionDto> CreateThumbInteraction(ThumbInteractionCreateDto newThumbInteraction);

        Task<bool> Update(ReviewUpdateDto updateReview);

        Task<ThumbInteractionDto> UpdateThumbInteraction(ThumbInteractionUpdateDto updateThumbInteraction);
    }
}
