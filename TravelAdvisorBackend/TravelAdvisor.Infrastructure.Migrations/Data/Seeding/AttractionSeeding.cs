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
    public static class AttractionSeeding
    {
        public static void SeedAttraction(this ModelBuilder builder)
        {


            builder.Entity<Attraction>().HasData(
              new Attraction()
              {
                  Id = StaticEnums.attraction["STOCKHOLM"],
                  Address = "Stockholm Södra",
                  Details = "Stockholms södra station är en överbyggd järnvägsstation på Västra stambanan i stadsdelen Södermalm i centrala Stockholm. ",
                  Latitude = 45,
                  Longitude = 54,
                  Name = "Hamnen",
                  Price = 100,
                  Image = "",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
                  City = "Stockholm"
              },
              new Attraction()
              {
                  Id = StaticEnums.attraction["BERLIN"],
                  Address = "Berlin Norra",
                  Details = "Inräknat förorter har staden omkring 4,6 miljoner invånare och hela storstadsregionen 6,1 miljoner. ",
                  Latitude = 45,
                  Longitude = 54,
                  Name = "Shopping Center",
                  Price = 100,
                  Image = "",
                  Created = DateTime.Parse("2021-01-01"),
                  Modified = DateTime.Parse("2021-01-01"),
                  City = "Berlin"
              },
               new Attraction()
               {
                   Id = StaticEnums.attraction["OSLO"],
                   Address = "Oslo Centrum",
                   Details = "Oslo, från 1624 till 1925 Kristiania, äldst Anslo/Ásló/Ósló, är Norges huvudstad och administrativt är Oslo kommun ett eget fylke, med drygt 690 000 invånare. ",
                   Latitude = 45,
                   Longitude = 54,
                   Name = "Oslo Centrum",
                   Price = 100,
                   Image = "",
                   Created = DateTime.Parse("2021-01-01"),
                   Modified = DateTime.Parse("2021-01-01"),
                   City = "Oslo"
               },
                 new Attraction()
                 {
                     Id = StaticEnums.attraction["PRAG"],
                     Address = "Prag Centrum Norra",
                     Details = "Prag är huvudstad och största stad i Tjeckien samt är belägen vid floden Moldau.",
                     Latitude = 45,
                     Longitude = 54,
                     Name = "Prag Centrum Norra",
                     Price = 100,
                     Image = "",
                     Created = DateTime.Parse("2021-01-01"),
                     Modified = DateTime.Parse("2021-01-01"),
                     City = "Prag"
                 },
                new Attraction()
                {
                    Id = StaticEnums.attraction["ROME"],
                    Address = "Rom Colosseum",
                    Details = "Bygget som slutfördes av hans son Titus",
                    Latitude = 45,
                    Longitude = 54,
                    Name = "Rom Colosseum",
                    Price = 100,
                    Image = "",
                    Created = DateTime.Parse("2021-01-01"),
                    Modified = DateTime.Parse("2021-01-01"),
                    City = "Rom"
                }


          );
        }
    }
}
