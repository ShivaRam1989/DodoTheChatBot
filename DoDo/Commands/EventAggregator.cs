using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Commands
{
    /// <summary>
    /// This is the subscribtion that can be used while unsubscribing a particular message that is subscribed 
    /// </summary>
    /// <typeparam name="Tmessage"></typeparam>
    public class Subscription<Tmessage> : IDisposable
    {
        public readonly MethodInfo MethodInfo;
        private readonly EventAggregator EventAggregator;
        public readonly WeakReference TargetObjet;
        public readonly bool IsStatic;

        private bool isDisposed;
        public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
        {
            MethodInfo = action.Method;
            if (action.Target == null)
                IsStatic = true;
            TargetObjet = new WeakReference(action.Target);
            EventAggregator = eventAggregator;
        }

        ~Subscription()
        {
            if (!isDisposed)
                Dispose();
        }

        public void Dispose()
        {
            EventAggregator.UnSubscribe(this);
            isDisposed = true;
        }

        public Action<Tmessage> CreatAction()
        {
            if (TargetObjet.Target != null && TargetObjet.IsAlive)
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), TargetObjet.Target, MethodInfo);
            if (this.IsStatic)
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), MethodInfo);

            return null;
        }
    }

    /// <summary>
    /// This class is used to Publish , Subscribe , Unsubscribe messages which are generic types
    /// </summary>
    public class EventAggregator
    {
        private readonly object lockObj = new object();
        private Dictionary<Type, IList> subscriber;
        private static EventAggregator eventArg;
        public static EventAggregator getInstance()
        {
            if (eventArg == null)
            {
                eventArg = new EventAggregator();
            }
            return eventArg;
        }
        public EventAggregator()
        {
            subscriber = new Dictionary<Type, IList>();
        }
        /// <summary>
        /// This method is used to publish the message to all the classes that subscribes that particular message
        /// </summary>
        /// <typeparam name="TMessageType">A generic message type it can be class object or int or string or enum</typeparam>
        /// <param name="message">The message that you want to send to other class</param>
        public void Publish<TMessageType>(TMessageType message)
        {
            Type t = typeof(TMessageType);
            IList sublst;
            if (subscriber.ContainsKey(t))
            {
                lock (lockObj)
                {
                    sublst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
                }

                foreach (Subscription<TMessageType> sub in sublst)
                {
                    var action = sub.CreatAction();
                    if (action != null)
                        action(message);
                }
            }
        }
        /// <summary>
        /// This method subscribes the published message sent from the publisher class 
        /// </summary>
        /// <typeparam name="TMessageType">A generic message type it can be class object or int or string or enum</typeparam>
        /// <param name="action">The method or action that you want to perform with subscribed message as parameter</param>
        /// <returns>Subscription of that message type </returns>
        public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            var actiondetail = new Subscription<TMessageType>(action, this);

            lock (lockObj)
            {
                if (!subscriber.TryGetValue(t, out actionlst))
                {
                    actionlst = new List<Subscription<TMessageType>>();
                    actionlst.Add(actiondetail);
                    subscriber.Add(t, actionlst);
                }
                else
                {
                    actionlst.Add(actiondetail);
                }
            }

            return actiondetail;
        }
        /// <summary>
        /// This method is to unsubscribe the subscribed event which was saved as a subscription
        /// </summary>
        /// <typeparam name="TMessageType">A generic message type it can be class object or int or string or enum</typeparam>
        /// <param name="subscription">Subscription class object that has been returned from subscribe event</param>
        public void UnSubscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (subscriber.ContainsKey(t))
            {
                lock (lockObj)
                {
                    subscriber[t].Remove(subscription);
                }
                subscription = null;
            }
        }

    }
}
