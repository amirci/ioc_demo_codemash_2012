using System.Collections.Generic;
using System.Linq;

namespace MavenThought.MovieLibrary
{
    public class SimpleMovieRepository : IMovieRepository
    {
        private readonly IMovieFactory _factory;

        public SimpleMovieRepository(IMovieFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<IMovie> List
        {
            get { return Enumerable.Range(1, 10).Select(i => this._factory.Create()); }
        }
    }
}