namespace Monday.Messenger
{
    public class EventHandlerModel
    {
        public string Name { get; set; }
        public event PublishSubscribeEventHandler<object> PubSubEventHandler;

        public EventHandlerModel(string name)
        {
            Name = name;

            if (PubSubEventHandler is null)
                PublishSubscribe<object>.AddEvent(name, PubSubEventHandler);
        }
    }
}