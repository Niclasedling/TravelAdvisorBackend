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
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public string City { get; set; }



    }
}
