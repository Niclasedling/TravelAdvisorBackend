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

        public string Adress { get; set; }

        public string Location { get; set; }

        public int? Price { get; set; }

        public string Details { get; set; }

        public List<Rating> Ratings { get; set; }

        //public List<Review> Reviews { get; set; }

    }

    public class AttractionDto : AttractionBase
    {

    }

    public class AttractionUpdateDto : AttractionBase
    {

    }

    public class AttractionDeleteDto
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

        public string Adress { get; set; }

        public string Location { get; set; }

        public int? Price { get; set; }

        public string Details { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<Review> Reviews { get; set; }

        public AttractionCreateDto()
        {
            Ratings = new List<Rating>(); // Titta vidare
        }
    }
}
