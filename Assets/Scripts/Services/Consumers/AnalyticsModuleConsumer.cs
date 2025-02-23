using System.Collections.Generic;
using DefaultNamespace.Services.Analytics;
using UnityEngine;

namespace DefaultNamespace.Services.Consumers
{
    public class AnalyticsModuleConsumer : MonoBehaviour
    {
        private AnalyticsModule _analyticsModule = new();
/*
        public void SaveNewData(string id, List<string> data)
        {
            _analyticsModule.SaveNewData(id, data);    
        }

        public void AddToAnalytics()
        {
            var storage = ServiceLocator.GetService<AnalyticsStorage>();
            _analyticsModule.AddToOrUpdateAnalytics(storage);
            
            //TODO: remove this line and make an event
            storage.SaveAnalyticsPermanent();
        }
            */
    }
}