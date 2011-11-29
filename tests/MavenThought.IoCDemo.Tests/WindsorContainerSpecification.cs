using Castle.Windsor;
using MavenThought.Commons.Testing;

namespace MavenThought.IoCDemo.Tests
{
    /// <summary>
    /// Base specification for WindsorContainer
    /// </summary>
    public abstract class WindsorContainerSpecification
        : AutoMockSpecificationWithNoContract<WindsorContainer>
    {
        protected override WindsorContainer CreateSut()
        {
            return new WindsorContainer();
        }

        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.GivenIRegister();
        }

        protected abstract void GivenIRegister();
    }
}