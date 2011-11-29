using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    public class When_single_interface_is_registered : WindsorContainerSpecification
    {
        private IMovie _actual;

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component
                    .For<IMovie>()
                    .ImplementedBy<Movie>() // Interface IMovie registered
                );
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.Resolve<IMovie>();
        }

        /// <summary>
        /// Checks that the instance is movie
        /// </summary>
        [It]
        public void Should_obtain_an_instance_of_movie()
        {
            this._actual.Should().Be.InstanceOf<Movie>();
        }
    }
}