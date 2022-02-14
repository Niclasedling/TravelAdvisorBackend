using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Data;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(DbApplicationContext context)
        {
            this.context = context;
        }

        private readonly DbApplicationContext context;

        private Repository<User> userRepository;
        private Repository<Attraction> attractionRepository;
        private Repository<Review> reviewRepository;
        private Repository<Comment> commentRepository;
        private Repository<ThumbInteraction> thumbInteractionRepository;

        Repository<User> IUnitOfWork.UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new Repository<User>(context);
                }
                return userRepository;
            }
        }

        Repository<Attraction> IUnitOfWork.AttractionRepository
        {
            get
            {
                if (this.attractionRepository == null)
                {
                    this.attractionRepository = new Repository<Attraction>(context);
                }
                return attractionRepository;
            }
        }

        Repository<Review> IUnitOfWork.ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new Repository<Review>(context);
                }
                return reviewRepository;
            }
        }
        Repository<Comment> IUnitOfWork.CommentRepository
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new Repository<Comment>(context);
                }
                return commentRepository;
            }
        }
        Repository<ThumbInteraction> IUnitOfWork.ThumbInteractionRepository
        {
            get
            {
                if (this.thumbInteractionRepository == null)
                {
                    this.thumbInteractionRepository = new Repository<ThumbInteraction>(context);
                }
                return thumbInteractionRepository;
            }
        }

        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }


    }
}
