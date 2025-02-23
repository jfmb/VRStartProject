﻿using UnityEngine;

namespace Services.EventQueue.Events.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SimpleEventSO", menuName = "Events/Create SimpleEventSO", order = 0)]
    public class SimpleEventSO : EventSO
    {
        public SimpleEventSO()
        {
            _eventSender = new SimpleEvent();
        }
    }
}