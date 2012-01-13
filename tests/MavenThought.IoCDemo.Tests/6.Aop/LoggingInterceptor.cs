using System.Diagnostics;
using Castle.DynamicProxy;

namespace MavenThought.IoCDemo.Tests
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine("Before execution");
            invocation.Proceed();
            Debug.WriteLine("After execution");
        }
    }
}