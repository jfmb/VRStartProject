using System;
using System.Collections.Generic;
using DefaultNamespace.Services.Analytics.DataType;
using Services.Counters;
using Services.EventQueue;
using Services.EventQueue.Events.Classes.EventData;
using Services.EventQueue.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Services.Counters
{
    public class CountersInScene : MonoBehaviour
    {
        [SerializeField] private EventId analyticsEventId;
        [SerializeField] private EventId saveCountersEventId;
        [SerializeField] private EventId saveAnalyticsPermanentId;
        
        private CountersProvider _counters;

        private bool _areCountersEnabled = true;
        
        private void Start()
        {
            _counters = ServiceLocator.GetService<CountersProvider>();

            var saveDataPermanentEvent =
                (SimpleEvent) ServiceLocator.GetService<EventQueue>().GetEventWithEventId(saveCountersEventId);
            saveDataPermanentEvent.SimpleEventSender += OnNewSaveDataPermanentEvent;
        }

        private void Update()
        {
            if (!_areCountersEnabled)
            {
                return;
            }
            
            UpdateEnabledCounters();
        }

        private void UpdateEnabledCounters()
        {
            if (_counters.AllCounters == null)
            {
                return;
            }
            foreach (var counter in _counters.AllCounters)
            {
                if (!counter.Value.IsEnabled)
                {
                    continue;
                }

                var currentCounterValue = counter.Value.CurrentValue;  
                counter.Value.AddToCurrentValue(Time.deltaTime);
            }
        }

        private void OnNewSaveDataPermanentEvent()
        {
            SaveCountersInAnalytics();
        }

        private void SaveCountersInAnalytics()
        {
            Debug.Log("Saving counters permanently");
            
            foreach (var counter in _counters.AllCounters)
            {
                counter.Value.IsEnabled = false;
                
                var counterInfoToSave = new List<string>
                {
                    counter.Value.CurrentValue.ToString(),
                    "seconds viewed ",
                };

                AddMoreInfoInCaseOfAVideo(counter, counterInfoToSave);
                
                
                var newAnalyticsDataType = new AnalyticsDataType(counter.Value.ID, counterInfoToSave);
                var newAnalyticsEventData = new AnalyticsEventData(newAnalyticsDataType);
                
                ServiceLocator.GetService<EventQueue>().EnqueueEvent(analyticsEventId, newAnalyticsEventData);
            }
            
            ServiceLocator.GetService<EventQueue>().EnqueueEvent(saveAnalyticsPermanentId, EventArgs.Empty);
        }

        private void AddMoreInfoInCaseOfAVideo(KeyValuePair<string, CounterData> counter,
            List<string> counterInfoToSave)
        {
            if (counter.Value.ValueForRefence == 0)
            {
                return;
            }
            
            counterInfoToSave.Add("of ");
            counterInfoToSave.Add(counter.Value.ValueForRefence.ToString());
            counterInfoToSave.Add(" seconds total");
        }

        private void OnDisable()
        {
            var saveDataPermanentEvent =
                (SimpleEvent) ServiceLocator.GetService<EventQueue>().GetEventWithEventId(saveCountersEventId);
            saveDataPermanentEvent.SimpleEventSender -= OnNewSaveDataPermanentEvent;        }
    }
}