using Reviefy.Models;

namespace Reviefy
{
    
    // ViewModel is nothing but a single class that may have multiple models.
    // It contains multiple models as a property. It should not contain any method.
    public class ViewModelObject
    {
        public Movie Movie { get; set; }

        public MoviePhoto MoviePhoto { get; set; }

        public News News { get; set; }

        public Review Review { get; set; }

        public User User { get; set; }
    }
}