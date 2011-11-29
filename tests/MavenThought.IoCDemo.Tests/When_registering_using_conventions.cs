using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_using_conventions : WindsorContainerSpecification
    {
        private IMovie[] _actual;

        private readonly Type[] _expected = new[] { typeof (Movie), typeof (RottenTomatoesMovie), typeof (NHMovie) };

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Classes
                    .FromAssemblyContaining<IMovie>()
                    .BasedOn<IMovie>()
                    .WithService.Base()
                    .LifestyleTransient()
                );
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.ResolveAll<IMovie>();
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