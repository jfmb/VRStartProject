using System;
using DefaultNamespace.Services.Analytics.DataType;

namespace Services.EventQueue.Events.Classes.EventData
{
    public class AnalyticsEventData: EventArgs
    {
        private AnalyticsDataType _analyticsData;

        public AnalyticsDataType AnalyticsData => _analyticsData;

        public AnalyticsEventData(AnalyticsDataType analyticsData)
        {
            _analyticsData = analyticsData;
        }
    }
}