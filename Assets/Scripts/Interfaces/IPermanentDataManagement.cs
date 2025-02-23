using System.Collections.Generic;

namespace DefaultNamespace.Services.Interfaces
{
    public interface IPermanentDataManagement
    {
        public void LoadSingleData(string key);
        public void LoadAllData();
        
        public void SaveSingleData(string key, string data);
        public void SaveGroupData(Dictionary<string, string> data);
    }
}