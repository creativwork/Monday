using System;

namespace Monday.Messenger
{
    public class PublishSubscribeEventArgs<T> : EventArgs
    {
        public T Item { get; private set; }
        public PublishSubscribeEventArgs(T item) => Item = item;
    }
}