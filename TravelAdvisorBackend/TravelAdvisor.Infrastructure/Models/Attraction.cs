using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Models
{
    public abstract class AttractionBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Price { get; set; }
        public string Details { get; set; }
        public string City { get; set; }


    }

    public class AttractionDto : AttractionBase
    {

    }

    public class AttractionUpdateDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Price { get; set; }
        public string Details { get; set; }


    }

    public class AttractionDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class AttractionAddReviewDto
    {
        public Guid Id { get; set; }
    }

    public class AttractionBasicDto
    {

    }

    public class AttractionCreateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Price { get; set; }
        public string Details { get; set; }
        public string City { get; set; }

    }
}
