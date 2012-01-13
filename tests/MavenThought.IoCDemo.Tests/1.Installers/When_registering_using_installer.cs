using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    public class When_registering_using_installer : WindsorContainerSpecification
    {
        private IMovie _actual;

        protected override void GivenIRegister()
        {
            this.Sut.Install(FromAssembly.This());
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.Resolve<IMovie>();
        }

        [It]
        public void Should_return_the_same_instance()
        {
            this._actual.Should().Be.InstanceOf<Movie>();
        }
    }

    public class MovieInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
        /// </summary>
        /// <param name="container">The container.</param><param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                                   .For<IMovie>()
                                   .ImplementedBy<Movie>()
                                   .LifeStyle.Transient);
        }
    }
}