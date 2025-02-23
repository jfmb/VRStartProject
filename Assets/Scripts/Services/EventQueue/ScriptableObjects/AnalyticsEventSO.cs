using Services.EventQueue.Events.Classes;
using UnityEngine;

namespace Services.EventQueue.Events.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AnalyticsEventSO", menuName = "Events/Create AnalyticsEventSO", order = 5)]
    public class AnalyticsEventSO : EventSO
    {
        public AnalyticsEventSO()
        {
            _eventSender = new AnalyticsEvent();
        }
    }
}