using AutoMapper;
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
    public class AttractionService : IAttractionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttractionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AttractionCreateDto> Create(AttractionCreateDto newAttraction)
        {
            if (newAttraction == null)
            {
                throw new Exception();
            }

            var attraction = _mapper.Map<Attraction>(newAttraction);
            await _unitOfWork.AttractionRepository.AddAsync(attraction);

            await _unitOfWork.SaveChanges();

            return _mapper.Map<AttractionCreateDto>(attraction);

        }

        public async Task<bool> Delete(Guid id)
        {
            var attraction = await _unitOfWork.AttractionRepository.GetByGuidAsync(id);
            bool success = false;

            if (attraction != null)
            {
                await _unitOfWork.AttractionRepository.RemoveAsync(attraction);
                await _unitOfWork.SaveChanges();
                success = true;

            }
            return success;
        }

        public async Task<AttractionDto> GetAll()
        {
            var attractions = await _unitOfWork.AttractionRepository.GetAllAsync();

            if (attractions != null)
            {
                return _mapper.Map<AttractionDto>(attractions);
            }

            return null; //Lägg till felmeddelande
        }

        public async Task<AttractionDto> GetById(Guid id)
        {
            var attraction = await _unitOfWork.AttractionRepository.GetByGuidAsync(id);

            if (attraction != null)
            {
                return _mapper.Map<AttractionDto>(attraction);
            }

            return null; //Lägg till felmeddelande.
        }

        public async Task<List<AttractionDto>> GetList()
        {
            var attractions = await _unitOfWork.AttractionRepository.GetAllAsync();

            if (attractions != null)
            {
                return _mapper.Map<List<AttractionDto>>(attractions);
            }

            return null; //Lägg till felmeddelande
        }

        public async Task<AttractionDto> Update(AttractionUpdateDto updateAttraction)
        {
            if (updateAttraction == null)
            {
                throw new ArgumentNullException(nameof(updateAttraction));
            }

            var attraction = _mapper.Map<Attraction>(updateAttraction);
            await _unitOfWork.AttractionRepository.UpdateAsync(attraction);

            await _unitOfWork.SaveChanges();
            var dbAttraction = _mapper.Map<AttractionUpdateDto>(await _unitOfWork.AttractionRepository.GetByGuidAsync(updateAttraction.Id));

            if (dbAttraction == updateAttraction)
            {
                return _mapper.Map<AttractionDto>(dbAttraction);
            }
            else
            {
                return null; //Lägg till felmeddelande
            }
        }
    }
}
