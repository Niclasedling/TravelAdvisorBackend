using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Migrations.Models
{

    public class Attraction: Entity
    {
        [Required]
        [StringLength(100)]
        //[Column(TypeName = "NVARCHAR(100)")] 
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        [Required]
        [StringLength(100)]
        public string Adress { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        [StringLength(1000)]
        public string Details { get; set; }

        [Required]
        public List<Rating> Ratings { get; set; } 

        [Required]
        public List<Review> Reviews { get; set; }

    }
}
