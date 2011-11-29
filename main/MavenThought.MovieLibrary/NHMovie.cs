namespace MavenThought.MovieLibrary
{
    public class NHMovie : IMovie
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }
    }
}