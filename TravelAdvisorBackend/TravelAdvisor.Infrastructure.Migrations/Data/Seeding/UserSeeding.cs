using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Enum;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Migrations.Data.Seeding
{
    public static class UserSeeding
    {

        public static void SeedUsers(this ModelBuilder builder)
        {
            //Password = HejHopp

            builder.Entity<User>().HasData(
              new User()
              {
                  Id = StaticEnums.users["PONTUS"],
                  FirstName = "Pontus",
                  LastName = "Bjornfot", 
                  Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                  Email = "Pontus.Bjornfot@outlook.com",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
              },
              new User()
              {
                  Id = StaticEnums.users["ROBIN"],
                  FirstName = "Robin",
                  LastName = "Robin",
                  Email = "Robin.Edin@gmail.com",
                  Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
              },
               new User()
               {
                   Id = StaticEnums.users["ALEX"],
                   FirstName = "Alex",
                   LastName = "Stenberg",
                   Email = "Alex.Stenberg@gmail.com",
                   Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                   Created = DateTime.Parse("2021-01-01"),
                   Modified = DateTime.Parse("2021-01-01"),
               },
                 new User()
                 {
                     Id = StaticEnums.users["JENS"],
                     FirstName = "Jens",
                     LastName = "Svensson",
                     Email = "Jens.Svensson@gmail.com",
                     Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                     Created = DateTime.Parse("2021-01-01"),
                     Modified = DateTime.Parse("2021-01-01"),
                 },
                  new User()
                  {
                      Id = StaticEnums.users["JOHAN"],
                      FirstName = "Johan",
                      LastName = "Andersson",
                      Email = "Johan.Andersson@gmail.com",
                      Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                      Created = DateTime.Parse("2021-01-01"),
                      Modified = DateTime.Parse("2021-01-01"),
                  },
                   new User()
                   {
                       Id = StaticEnums.users["MATTIAS"],
                       FirstName = "Mattias",
                       LastName = "Andersson",
                       Email = "Mattias.Andersson@gmail.com",
                       Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                       Created = DateTime.Parse("2021-01-01"),
                       Modified = DateTime.Parse("2021-01-01"),
                   },
                    new User()
                    {
                        Id = StaticEnums.users["NICKI"],
                        FirstName = "Nicki",
                        LastName = "Edling",
                        Email = "Nicki.Edling@gmail.com",
                        Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                        Created = DateTime.Parse("2021-01-01"),
                        Modified = DateTime.Parse("2021-01-01"),
            
                    }

          );
        }
    }
}
