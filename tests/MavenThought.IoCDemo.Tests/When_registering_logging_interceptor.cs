using Castle.Core;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using Component = Castle.MicroKernel.Registration.Component;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_logging_interceptor : WindsorContainerSpecification
    {
        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component
                    .For<LoggingInterceptor>()
                    .LifeStyle.Transient,
                Component
                    .For<IMovie>()
                    .ImplementedBy<NHMovie>()
                    .Interceptors(InterceptorReference.ForType<LoggingInterceptor>()).Anywhere
                    .LifeStyle.Transient
                );
        }

        protected override void WhenIRun()
        {
            var vm = this.Sut.Resolve<IMovie>();

            vm.Title = "New title";
        }

        [It]
        public void Should_log_the_call()
        {
        }
    }
}