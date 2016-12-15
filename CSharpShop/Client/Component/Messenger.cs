using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Component
{
    /// <summary>
    /// Messenger for ViewModel
    /// </summary>
    public class Messenger : IMessenger
    {
        protected static readonly object locker;
        protected static readonly ConcurrentDictionary<MessengerKey, object> messages;
        /// <summary>
        /// Singleton pattern implemintation
        /// </summary>
        #region singleton implemintation
        private static Messenger instance;
        public static Messenger Instance
        {
            get { return GetInstance(); }
        }
        private static Messenger GetInstance()
        {
            lock(locker)
            {
                if (instance == null)
                {
                    instance = new Messenger();
                }
            }
            return instance;
        }
        private Messenger() { }
        static Messenger()
        {
            locker = new object();
            messages = new ConcurrentDictionary<MessengerKey, object>();
        }
        #endregion
        /// <summary>
        /// Registers a recipient for a type of message T. The action parameter will be executed
        /// when a corresponding message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="action"></param>
        public void Register<T>(object recipient, Action<T> action)
        {
            Register(recipient, action, null);
        }

        /// <summary>
        /// Registers a recipient for a type of message T and a matching context. The action parameter will be executed
        /// when a corresponding message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Register<T>(object recipient, Action<T> action, object context)
        {
            var key = new MessengerKey(recipient, context);
            messages.TryAdd(key, action);
        }

        /// <summary>
        /// Unregisters a messenger recipient completely. After this method is executed, the recipient will
        /// no longer receive any messages.
        /// </summary>
        /// <param name="recipient"></param>
        public void Unregister(object recipient)
        {
            Unregister(recipient, null);
        }

        /// <summary>
        /// Unregisters a messenger recipient with a matching context completely. After this method is executed, the recipient will
        /// no longer receive any messages.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="context"></param>
        public void Unregister(object recipient, object context)
        {
            object action;
            var key = new MessengerKey(recipient, context);
            messages.TryRemove(key, out action);
        }

        /// <summary>
        /// Sends a message to registered recipients. The message will reach all recipients that are
        /// registered for this message type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void Send<T>(T message)
        {
            Send(message, null);
        }

        /// <summary>
        /// Sends a message to registered recipients. The message will reach all recipients that are
        /// registered for this message type and matching context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void Send<T>(T message, object context)
        {
            IEnumerable<KeyValuePair<MessengerKey, object>> result;

            if (context == null)
            {
                // Get all recipients where the context is null.
                //result = from r in Dictionary where r.Key.Context == null select r;
                result = messages.Where(r => r.Key.Context == null);
            }
            else
            {
                // Get all recipients where the context is matching.
                //result = from r in Dictionary where r.Key.Context != null && r.Key.Context.Equals(context) select r;
                result = messages.Where(r => r.Key.Context != null && r.Key.Context.Equals(context));
            }

            foreach (var action in result.Select(x => x.Value).OfType<Action<T>>())
            {
                // Send the message to all recipients.
                action(message);
            }
        }
        protected class MessengerKey
        {
            public object Recipient { get; protected set; }
            public object Context { get; protected set; }
            public MessengerKey(object recipient, object context)
            {
                this.Recipient = recipient;
                this.Context = context;
            }

            /// <summary>
            /// Determines whether the specified MessengerKey is equal to the current MessengerKey.
            /// </summary>
            /// <param name="other">other messenger key</param>
            /// <returns>bool result of comparasion</returns>
            protected bool Equals(MessengerKey other)
            {
                return Equals(Recipient, other.Recipient) && Equals(Context, other.Context);
            }

            /// <summary>
            /// Determines whether the specified MessengerKey is equal to the current MessengerKey.
            /// </summary>
            /// <param name="obj">other object type</param>
            /// <returns>bool result of comparison</returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != GetType())
                {
                    return false;
                }
                return Equals((MessengerKey)obj);
            }

            /// <summary>
            /// Serves as a hash function for a particular type. 
            /// </summary>
            /// <returns>hash code</returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return (Recipient != null ? Recipient.GetHashCode() : 0) ^ (Context != null ? Context.GetHashCode() : 0);
                }
            }
        }
    }
}
