using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IAttractionService
    {
        Task<AttractionDto> GetById(Guid id);

        Task<AttractionDto> GetAll();

        Task<List<AttractionDto>> GetList();

        Task<bool> Delete(Guid id);

        Task<AttractionCreateDto> Create(AttractionCreateDto newAttraction);

        Task<AttractionDto> Update(AttractionUpdateDto updateAttraction);
    }
}
