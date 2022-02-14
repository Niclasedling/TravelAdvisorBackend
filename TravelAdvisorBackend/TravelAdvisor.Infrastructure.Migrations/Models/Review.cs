using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Migrations.Models
{
    public enum Rating
    {
        Unspecified,
        VeryBad,
        Bad,
        Average,
        VeryGood,
        Excellent,
    }

    public class Review : Entity
    {
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("AttractionId")]
        public virtual Attraction Attraction { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Dislikes { get; set; }

    }
}
