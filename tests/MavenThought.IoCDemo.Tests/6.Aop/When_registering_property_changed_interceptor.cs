using System.Collections.Generic;
using Castle.Core;
using MavenThought.Commons.Testing;
using MavenThought.MovieLibrary;
using SharpTestsEx;
using Component = Castle.MicroKernel.Registration.Component;

namespace MavenThought.IoCDemo.Tests
{
    [Specification]
    public class When_registering_property_changed_interceptor : WindsorContainerSpecification
    {
        private readonly ICollection<string> _propertyChanged = new List<string>();

        protected override void GivenIRegister()
        {
            this.Sut.Register(
                Component
                    .For<NotifyPropertyChangedInterceptor>()
                    .LifeStyle.Transient,
                Component
                    .For<IMovieViewModel>()
                    .ImplementedBy<MovieViewModel>()
                    .Interceptors(InterceptorReference.ForType<NotifyPropertyChangedInterceptor>()).Anywhere
                    .LifeStyle.Transient
                );
        }

        protected override void WhenIRun()
        {
            var vm = this.Sut.Resolve<IMovieViewModel>();

            vm.PropertyChanged += (s, e) => this._propertyChanged.Add(e.PropertyName);

            vm.Title = "Blazing Saddles";
            vm.Description = "A sheriff goes to a town";
        }

        [It]
        public void Should_register_the_property_changed()
        {
            this._propertyChanged
                .Should()
                .Have
                .SameSequenceAs(new[]
                                    {
                                        "Title",
                                        "Description"
                                    });
        }
    }
}