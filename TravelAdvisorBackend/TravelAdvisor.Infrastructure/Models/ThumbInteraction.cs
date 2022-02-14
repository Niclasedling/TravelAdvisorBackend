using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Models
{
    public abstract class ThumbInteractionBase
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public bool HasLiked { get; set; }
    }

    public class ThumbInteractionDto : ThumbInteractionBase
    {

    }

    public class ThumbInteractionUpdateDto : ThumbInteractionBase
    {

    }

    public class ThumbInteractionDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class ThumbInteractionCreateDto
    {
        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public bool HasLiked { get; set; }

    }
}
