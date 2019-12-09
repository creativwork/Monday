using System.Collections.Generic;
using System.Linq;

namespace Monday.Messenger
{
    public static class EventHandler
    {
        private static List<EventHandlerModel> EventHandlers { get; set; } = new List<EventHandlerModel>();

        public static void AddEvent(string name)
        {
            if (EventHandlers.Any(x => x.Name == name))
                return;

            EventHandlers.Add(new EventHandlerModel(name));
        }
    }
}