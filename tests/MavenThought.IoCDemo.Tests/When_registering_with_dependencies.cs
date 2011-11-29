using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_with_dependencies : WindsorContainerSpecification
    {
        private IEnumerable<IMovie> _actual;
        private readonly string[] _names = new[] { "Movie", "RottenTomatoesMovie", "NHMovie" };
        private readonly Type[] _expected = new[] { typeof(Movie), typeof(RottenTomatoesMovie), typeof(NHMovie) };

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                );
        }
    }
}