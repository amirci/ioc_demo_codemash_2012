using System.Linq;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_with_dependencies : WindsorContainerSpecification
    {
        private IMovieRepository _repository;

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                    Component.For<IMovieFactory>().ImplementedBy<NHMovieFactory>(),
                    Component.For<IMovieRepository>().ImplementedBy<SimpleMovieRepository>()
                );
        }

        protected override void WhenIRun()
        {
            this._repository = this.Sut.Resolve<IMovieRepository>();
        }

        /// <summary>
        /// Checks that is the right factory
        /// </summary>
        [It]
        public void Should_return_all_nh_movies()
        {
            this._repository.List
                .All(x => x.GetType() == typeof(NHMovie))
                .Should()
                .Be
                .True();
        }
    }
}