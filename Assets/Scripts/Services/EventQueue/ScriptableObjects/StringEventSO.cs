using System;
using Services.EventQueue.Events.Interfaces;
using UnityEngine;

namespace Services.EventQueue.Events.ScriptableObjects
{
    [CreateAssetMenu(fileName = "StringEventSO", menuName = "Events/Create StringEventSO", order = 2)]
    public class StringEventSO : EventSO
    {
        public StringEventSO()
        {
            _eventSender = new StringEvent();
        }
    }
}