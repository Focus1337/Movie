using System.Collections.Generic;

namespace Reviefy.Models
{
    // ViewModel is nothing but a single class that may have multiple models.
    // It contains multiple models as a property. It should not contain any method.
    public class ViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<MoviePhoto> MoviePhotos { get; set; }
        public List<News> News { get; set; }
        public List<Review> Reviews { get; set; }
        public List<User> Users { get; set; }


        public Movie MovieById { get; set; }
        public MoviePhoto MoviePhotoById { get; set; }
        public News NewsById { get; set; }
        public Review ReviewById { get; set; }
        public User UserById { get; set; }
    }
}