using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Repository;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();
        Repository<User> UserRepository
        {
            get;
        }
        Repository<Attraction> AttractionRepository
        {
            get;
        }
        Repository<Review> ReviewRepository
        {
            get;
        }
        Repository<Comment> CommentRepository
        {
            get;
        }
        Repository<ThumbInteraction> ThumbInteractionRepository
        {
            get;
        }
    }
}
