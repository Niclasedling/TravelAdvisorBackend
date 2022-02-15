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
        Task<List<ThumbInteractionDto>> GetById(Guid id);

        Task<ThumbInteractionDto> GetAll();

        Task<List<ThumbInteractionDto>> GetList();
    

        Task<bool> Delete(Guid id);

        Task<Guid> Create(ThumbInteractionCreateDto thumbInteractionCreateDto);

        Task<bool> Update(ThumbInteractionUpdateDto  thumbInteractionUpdateDto);
    }
}
