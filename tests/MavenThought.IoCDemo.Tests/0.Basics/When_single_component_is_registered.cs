using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    public class When_single_component_is_registered : WindsorContainerSpecification
    {
        private Movie _actual;

        protected override void GivenIRegister()
        {
            // Movie class registered
            Sut.Register(Component.For<Movie>());
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.Resolve<Movie>();
        }

        [It]
        public void Should_obtain_an_instance_of_movie()
        {
            this._actual.Should().Be.InstanceOf<Movie>();
        }
    }
}
