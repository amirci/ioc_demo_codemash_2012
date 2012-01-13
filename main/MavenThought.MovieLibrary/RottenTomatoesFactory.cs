namespace MavenThought.MovieLibrary
{
    public class RottenTomatoesFactory : IMovieFactory
    {
        private readonly string _apiKey;

        public RottenTomatoesFactory(string apiKey)
        {
            _apiKey = apiKey;
        }

        public IMovie Create()
        {
            // call api using the key
            return new RottenTomatoesMovie();
        }
    }
}