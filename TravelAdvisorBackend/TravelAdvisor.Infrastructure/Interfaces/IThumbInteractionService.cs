using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Interfaces
{
public interface IThumbInteractionService
    {
        Task<Guid> Create(ThumbInteractionCreateDto thumbInteractionCreateDto);

        Task<List<ThumbInteractionDto>> GetById(Guid id);

        Task<List<ThumbInteractionDto>> GetAll();

        Task<List<ThumbInteractionDto>> GetList();

        Task<List<ThumbInteractionDto>> GetListById(Guid id);
        Task<ThumbInteractionDto> GetByUserId(Guid userId);

        Task<bool> Update(ThumbInteractionUpdateDto thumbInteractionUpdateDto);

        Task<bool> Delete(Guid id);
    }
}
