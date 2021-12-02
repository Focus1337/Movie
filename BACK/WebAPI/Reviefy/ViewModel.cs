using System.Collections.Generic;
using Reviefy.Models;

namespace Reviefy
{
    // ViewModel is nothing but a single class that may have multiple models.
    // It contains multiple models as a property. It should not contain any method.
    public class ViewModel
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}