using System;
using Castle.MicroKernel.Registration;
using MavenThought.MovieLibrary;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_lifestyle_is_singleton : WindsorContainerSpecification
    {
        private IMovie _actual1;
        private IMovie _actual2;

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component.For<IMovie>().ImplementedBy<Movie>()
                );
        }

        protected override void WhenIRun()
        {
            this._actual1 = this.Sut.Resolve<IMovie>();
            this._actual2 = this.Sut.Resolve<IMovie>();
        }

        /// <summary>
        /// Checks that the same instance is returned
        /// </summary>
        [It]
        public void Should_return_the_same_instance()
        {
            this._actual1.Should().Be(this._actual2);
        }
    }
}