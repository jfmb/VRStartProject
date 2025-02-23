using System.Collections.Generic;
using DefaultNamespace.Services.Analytics;
using Services.EventQueue;
using Services.EventQueue.Events.Classes;
using Services.EventQueue.Events.Classes.EventData;
using Services.EventQueue.Events.ScriptableObjects;
using UnityEngine;

public class AnalyticsEventReceiver : MonoBehaviour
{
    [SerializeField] private EventId analyticsEventId;
    [SerializeField] private EventId saveAnalyticsPermanentEventId;
    
    private Dictionary<string, AnalyticsModule> allAnalyticsModules = new();
    private AnalyticsStorage _storage;
    
    private void Start()
    {
        var analyticsEvent = (AnalyticsEvent) ServiceLocator.GetService<EventQueue>().GetEventWithEventId(analyticsEventId);
        analyticsEvent.AnalyticsEventSender += OnNewAnalyticsEvent;

        var saveDataPermanentEvent = (SimpleEvent)ServiceLocator.GetService<EventQueue>()
            .GetEventWithEventId(saveAnalyticsPermanentEventId);
        saveDataPermanentEvent.SimpleEventSender += OnNewSaveAnalyticsPermanentEvent;
        
        _storage = ServiceLocator.GetService<AnalyticsStorage>();
    }


    private void OnNewAnalyticsEvent(object source, AnalyticsEventData args)
    {
        var key = args.AnalyticsData.ID;
                
        var newAnalyticsModule = new AnalyticsModule();
        newAnalyticsModule.SaveNewData(key, args.AnalyticsData.Data);
        
        if (allAnalyticsModules.ContainsKey(key))
        {
            allAnalyticsModules[key] = newAnalyticsModule;
            return;
        }
         
        allAnalyticsModules.Add(key, newAnalyticsModule);
        AddToAnalyticsWith(key);
    }

    private void AddToAnalyticsWith(string key)
    {
        allAnalyticsModules[key].AddToOrUpdateAnalytics(_storage);  
        
    }

    private void OnNewSaveAnalyticsPermanentEvent()
    {
        SaveAnalyticsPermanent();
    }

    
    public void SaveAnalyticsPermanent()
    {
        _storage.SaveAnalyticsPermanent();
    }

    private void OnDestroy()
    {
        var analyticsEvent = (AnalyticsEvent) ServiceLocator.GetService<EventQueue>().GetEventWithEventId(analyticsEventId);
        analyticsEvent.AnalyticsEventSender -= OnNewAnalyticsEvent;

        var saveDataPermanentEvent = (SimpleEvent)ServiceLocator.GetService<EventQueue>()
            .GetEventWithEventId(saveAnalyticsPermanentEventId);
        saveDataPermanentEvent.SimpleEventSender -= OnNewSaveAnalyticsPermanentEvent;
    }
}
