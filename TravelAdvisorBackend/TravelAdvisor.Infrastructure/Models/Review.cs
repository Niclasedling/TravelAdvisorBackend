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
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Rating Rating { get; set; }

        public List<int> Likes { get; set; } // Titta vidare på

        public UserDto User { get; set; }
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

        public Rating Rating { get; set; }

        public List<int> Likes { get; set; } // Titta vidare på

        public UserDto User { get; set; }

    }
}
