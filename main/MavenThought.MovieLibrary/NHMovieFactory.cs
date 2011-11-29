namespace MavenThought.MovieLibrary
{
    public class NHMovieFactory : IMovieFactory
    {
        public IMovie Create()
        {
            return new NHMovie();
        }
    }
}