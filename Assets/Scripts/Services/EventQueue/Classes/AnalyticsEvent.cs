using System;
using Services.EventQueue.Events.Classes.EventData;
using Services.EventQueue.Events.Interfaces;

namespace Services.EventQueue.Events.Classes
{
    public class AnalyticsEvent: IEventSender
    {
        public delegate void SendAnalyticsEventHandler(object source, AnalyticsEventData args);

        public event SendAnalyticsEventHandler AnalyticsEventSender;
        
        public void SendEvent(EventArgs args)
        {
            AnalyticsEventSender?.Invoke(this,(AnalyticsEventData) args);
        }
    }
}