using System;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_same_component_twice_with_names : WindsorContainerSpecification
    {
        private IMovie _actual;

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component
                    .For<IMovie>()
                    .ImplementedBy<Movie>()
                    .LifeStyle.Transient,
                Component
                    .For<IMovie>()
                    .ImplementedBy<RottenTomatoesMovie>()
                    .Named("RT")
                    .LifeStyle.Transient
                );
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.Resolve<IMovie>("RT");
        }

        [It]
        public void Should_return_the_named_instance()
        {
            this._actual.Should().Be.InstanceOf<RottenTomatoesMovie>();
        }
    }
}