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
    public static class ReviewSeeding
    {
        public static void SeedReview(this ModelBuilder builder)
        {

            builder.Entity<Review>().HasData(
              new Review()
              {
                  Id = StaticEnums.review["REVIEWGUID2"],
                  Attraction =  {
                  Id = StaticEnums.attraction["STOCKHOLM"],
                  Address = "Stockholm Södra",
                  Details = "Stockholms södra station är en överbyggd järnvägsstation på Västra stambanan i stadsdelen Södermalm i centrala Stockholm. ",
                  Latitude = 45,
                  Longitude = 54,
                  Name = "Stockholm",
                  Price = 100,
                  Image = "",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),

                  },
                  User = { 
                  Id = StaticEnums.users["PONTUS"],
                  FirstName = "Pontus",
                  LastName = "Bjornfot",
                  Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                  Email = "Pontus.Bjornfot@outlook.com",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
                  },
                  Rating = Rating.VeryBad,
                  Date = DateTime.Parse("2021-01-01"),
                  Description="Usel sevärdighet",
                  Title = "Åk ej",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
              },
              new Review()
              {
                  Id = StaticEnums.review["REVIEWGUID2"],
                  Attraction = {

                  Id = StaticEnums.attraction["BERLIN"],
                  Address = "Berlin Norra",
                  Details = "Inräknat förorter har staden omkring 4,6 miljoner invånare och hela storstadsregionen 6,1 miljoner. ",
                  Latitude = 45,
                  Longitude = 54,
                  Name = "Berlin",
                  Price = 100,
                  Image = "",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),

                  },
                  User = {
                   Id = StaticEnums.users["ROBIN"],
                  FirstName = "Robin",
                  LastName = "Robin",
                  Email = "Robin.Edin@gmail.com",
                  Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
                  },
                  Rating = Rating.Excellent,
                  Date = DateTime.Parse("2021-01-01"),
                  Description = "Super nöjd med min vistelse",
                  Title = "Super!",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
              }
              


          );
        }
    }
}
