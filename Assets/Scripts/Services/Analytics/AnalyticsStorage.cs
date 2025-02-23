using System.Collections.Generic;
using DefaultNamespace.Services.Interfaces;

namespace DefaultNamespace.Services.Analytics
{
    public class AnalyticsStorage
    {
        private Dictionary<string, string> _storage = new();

        public Dictionary<string, string> Storage => _storage;

        public void SaveAnalyticsPermanent()
        {
            ServiceLocator.GetService<IPermanentDataManagement>().SaveGroupData(_storage);
        }
    }
}