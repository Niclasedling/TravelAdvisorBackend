using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Migrations.Models
{

    public class Attraction: Location
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        [StringLength(1000)]
        public string Details { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Adress { get; set; }

        //[Required]
        //[StringLength(100)]
        //public (double Latitude, double Longitude) Location { get; set; }


    }
}
