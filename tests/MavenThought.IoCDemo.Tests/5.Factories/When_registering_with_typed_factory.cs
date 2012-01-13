using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_with_typed_factory : WindsorContainerSpecification
    {
        private IMovieFactory _factory;

        protected override void GivenIRegister()
        {
            this.Sut.Kernel.AddFacility<TypedFactoryFacility>();

            this.Sut.Register(
                Component.For<IMovie>().ImplementedBy<NHMovie>().LifeStyle.Transient,
                Component.For<IMovieFactory>().AsFactory()
            );
        }

        protected override void WhenIRun()
        {
            this._factory = this.Sut.Resolve<IMovieFactory>();
        }

        /// <summary>
        /// Checks that reason
        /// </summary>
        [It]
        public void Should_get_the_instance_from_the_container()
        {
            var movie1 = this._factory.Create();
            var movie2 = this._factory.Create();

            movie1.Should().Be.InstanceOf<NHMovie>();

            movie1.Should().Not.Be(movie2);
        }
    }
}