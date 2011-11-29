using System.Collections.Generic;

namespace MavenThought.MovieLibrary
{
    public interface IMovieRepository
    {
        IEnumerable<IMovie> List { get; }
    }
}