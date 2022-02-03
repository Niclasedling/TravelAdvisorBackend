using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Models
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

    public abstract class ReviewBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Rating Rating { get; set; }

        public AttractionDto attractionDto { get; set; }    

        public UserDto User { get; set; }

        // Comments / Likes
    }
    public class ReviewDto : ReviewBase
    {

    }

    public class ReviewUpdateDto : ReviewBase
    {

    }

    public class ReviewDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class ReviewBasicDto
    {

    }

    public class ReviewCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Rating Rating { get; set; } = Rating.Unspecified;

        public Guid UserId { get; set; } // Id

        public Guid AttractionId{ get; set; }

    }
}
