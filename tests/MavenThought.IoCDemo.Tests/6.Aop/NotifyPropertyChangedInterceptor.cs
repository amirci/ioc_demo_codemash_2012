using System.ComponentModel;
using Castle.DynamicProxy;

namespace MavenThought.IoCDemo.Tests
{
    public class NotifyPropertyChangedInterceptor : IInterceptor
    {
        private PropertyChangedEventHandler _subscribers = delegate { };

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.DeclaringType == typeof(INotifyPropertyChanged))
            {
                HandleSubscription(invocation);
                return;
            }

            invocation.Proceed();

            if (invocation.Method.Name.StartsWith("set_"))
            {
                FireNotificationChanged(invocation);
            }
        }

        private void HandleSubscription(IInvocation invocation)
        {
            var handler = (PropertyChangedEventHandler)invocation.Arguments[0];

            if (invocation.Method.Name.StartsWith("add_"))
            {
                _subscribers += handler;
            }
            else
            {
                _subscribers -= handler;
            }
        }

        private void FireNotificationChanged(IInvocation invocation)
        {
            var propertyName = invocation.Method.Name.Substring(4);
            _subscribers(invocation.Proxy, new PropertyChangedEventArgs(propertyName));
        }
    }
}