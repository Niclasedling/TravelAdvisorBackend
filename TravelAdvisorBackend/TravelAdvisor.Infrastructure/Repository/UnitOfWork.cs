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
