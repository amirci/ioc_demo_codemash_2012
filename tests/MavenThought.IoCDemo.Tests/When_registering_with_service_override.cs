using System.Linq;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_with_service_override : WindsorContainerSpecification
    {
        private IMovieRepository _repository;

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component
                    .For<IMovieFactory>()
                    .ImplementedBy<NHMovieFactory>()
                    .Named("nhFactory"),
                Component
                    .For<IMovieRepository>()
                    .ImplementedBy<SimpleMovieRepository>()
                    .DependsOn(Dependency.OnComponent("factory", "nhFactory"))
                );
        }

        protected override void WhenIRun()
        {
            this._repository = this.Sut.Resolve<IMovieRepository>();
        }

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