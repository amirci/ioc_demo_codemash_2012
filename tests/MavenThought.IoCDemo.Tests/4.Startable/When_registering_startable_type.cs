using System;
using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.IoCDemo.Tests
{
    public class CallActionOnStart : IStartable
    {
        private readonly Action _action;

        public CallActionOnStart(Action action)
        {
            _action = action;
        }

        public void Start()
        {
            _action();
        }

        public void Stop() {}
    }

    public class When_registering_startable_type : WindsorContainerSpecification
    {
        private bool _wasStarted;

        protected override void GivenIRegister()
        {
            this.Sut.Kernel.AddFacility<StartableFacility>();

            Action started = () => this._wasStarted = true;

            this.Sut.Register(
                Component
                    .For<CallActionOnStart>()
                    .DependsOn(new { action = started }));
        }

        protected override void WhenIRun()
        {
            // nothing to run
        }

        [It]
        public void Should_be_started()
        {
            this._wasStarted.Should().Be.True();
        }
    }
}