using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public IList<Genre> Genres{ get; set; }


    }
}