﻿using UnityEngine;

namespace Services.EventQueue.Events.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BooleanEventSO", menuName = "Events/Create BooleanEventSO", order = 1)]
    public class BooleanEventSO : EventSO
    {
        public BooleanEventSO()
        {
            _eventSender = new BooleanEvent();
        }
    }
}