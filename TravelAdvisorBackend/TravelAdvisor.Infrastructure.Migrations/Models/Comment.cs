using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Migrations.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

        public string UserComment { get; set; }
    }
}
