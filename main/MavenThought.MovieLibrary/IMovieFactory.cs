using System;

namespace MavenThought.MovieLibrary
{
    public interface IMovieFactory
    {
        IMovie Create();
    }
}