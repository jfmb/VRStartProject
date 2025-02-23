using System.Collections.Generic;
using DefaultNamespace.Services.Analytics.DataType;


namespace DefaultNamespace.Services.Analytics
{
    public class AnalyticsModule
    {
        private AnalyticsDataType _data;
        
        public void SaveNewData(string id, List<string> newData)
        {
            _data = new AnalyticsDataType(id, newData);
        }

        public void AddToOrUpdateAnalytics(AnalyticsStorage analytics)
        {
            var completeData = CreateOneSingleStringWithData();

            if (analytics.Storage.ContainsKey(_data.ID))
            {
                analytics.Storage[_data.ID] = completeData;
                return;
            }
            
            analytics.Storage.Add(_data.ID, completeData);
        }

        private string CreateOneSingleStringWithData()
        {
            var newValue = _data.Data[0];
            for (int i = 1; i < _data.Data.Count; i++)
            {
                newValue += " " + _data.Data[i];
            }

            return newValue;
        }
    }
}