using System.Collections.Generic;

namespace DefaultNamespace.Services.Analytics.DataType
{
    public class AnalyticsDataType
    {
        private string _id;
        private List<string> _data;
        
        public string ID => _id;
        public List<string> Data => _data;

        public AnalyticsDataType(string id, List<string> data)
        {
            _id = id;
            _data = data;
        }
    }
}