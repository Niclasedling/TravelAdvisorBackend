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
    public class CommentService : ICommentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<Guid> Create(CommentCreateDto commentCreateDto)
        {
            if (commentCreateDto == null) throw new NullReferenceException(nameof(commentCreateDto));

            var mappedComment = _mapper.Map<Comment>(commentCreateDto);

            mappedComment.Review = await _unitOfWork.ReviewRepository.GetByGuidAsync(commentCreateDto.ReviewId);
            mappedComment.User = await _unitOfWork.UserRepository.GetByGuidAsync(commentCreateDto.UserId);

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

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetById(Guid id)
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

        public Task<List<CommentDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CommentUpdateDto commentUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
