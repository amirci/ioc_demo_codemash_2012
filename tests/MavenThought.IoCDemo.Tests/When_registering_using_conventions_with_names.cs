using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_using_conventions_with_names : WindsorContainerSpecification
    {
        private IEnumerable<IMovie> _actual;
        private readonly string[] _names = new[] {"Movie", "RottenTomatoesMovie", "NHMovie"};
        private readonly Type[] _expected = new[] { typeof(Movie), typeof(RottenTomatoesMovie), typeof(NHMovie) };

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Classes
                    .FromAssemblyContaining<IMovie>()
                    .BasedOn<IMovie>()
                    .LifestyleTransient()
                    .Configure(reg => reg.Named(reg.Implementation.Name))
                );
        }

        protected override void WhenIRun()
        {
            this._actual = this._names.Select(n => this.Sut.Resolve<IMovie>(n));
        }

        /// <summary>
        /// Checks that the same instance is returned
        /// </summary>
        [It]
        public void Should_return_the_same_instance()
        {
            this._actual
                .Select(m => m.GetType())
                .Should()
                .Have
                .SameValuesAs(_expected);
        }
    }
}