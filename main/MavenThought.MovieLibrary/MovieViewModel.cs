using System.ComponentModel;

namespace MavenThought.MovieLibrary
{
    public class MovieViewModel : IMovieViewModel
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };
    }
}