using System.Linq;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    public class When_registering_with_dependencies : WindsorContainerSpecification
    {
        private IMovieRepository _repository;

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component
                    .For<IMovieFactory>()
                    .ImplementedBy<RottenTomatoesFactory>()
                    .DependsOn(new {apiKey = "someAssignedKey"}),
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
        public void Should_return_all_rt_movies()
        {
            this._repository.List
                .All(x => x.GetType() == typeof(RottenTomatoesMovie))
                .Should()
                .Be
                .True();
        }
    }
}