using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Models
{
    public abstract class CommentBase
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public string UserComment { get; set; }
        public DateTime CommentCreated { get; set; }
    }

    public class CommentDto : CommentBase
    {

    }

    public class CommentUpdateDto : CommentBase
    {

    }

    public class CommentDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class CommentBasicDto
    {

    }

    public class CommentCreateDto
    {
        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public string UserComment { get; set; }
        public DateTime CommentCreated { get; set; }

    }
}

