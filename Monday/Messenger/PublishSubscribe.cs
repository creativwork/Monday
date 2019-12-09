using System.Collections.Generic;

namespace Monday.Messenger
{
    public delegate void PublishSubscribeEventHandler<T>(object sender, PublishSubscribeEventArgs<T> args);

    public static class PublishSubscribe<T>
    {
        private static readonly Dictionary<string, PublishSubscribeEventHandler<T>> events =
            new Dictionary<string, PublishSubscribeEventHandler<T>>();

        internal static void AddEvent(string name, PublishSubscribeEventHandler<T> handler)
        {
            if (!events.ContainsKey(name))
                events.Add(name, handler);
        }
        public static void RaiseEvent(string name, object sender, PublishSubscribeEventArgs<T> args)
        {
            if (events.ContainsKey(name) && events[name] != null)
                events[name](sender, args);
        }
        public static void Subscribe(string name, PublishSubscribeEventHandler<T> handler)
        {
            EventHandler.AddEvent(name);

            if (events.ContainsKey(name))
                events[name] += handler;
        }
    }
}