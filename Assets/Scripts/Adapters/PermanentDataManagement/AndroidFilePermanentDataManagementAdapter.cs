using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultNamespace.Services.Interfaces;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace DefaultNamespace.Services.Adapters.PermanentDataManagement
{
    public class AndroidFilePermanentDataManagementAdapter: IPermanentDataManagement
    {
        private static readonly string SessionId = System.DateTime.Now.ToString("\nyyyy/MM/dd-HH:mm:ss");
        private static readonly string Date = System.DateTime.Now.ToString("yyyyMMdd");

//        private static readonly string Path = ("/sdcard/Download/ESICM/Report" + Date + ".txt");
        
        public void LoadSingleData(string key)
        {
            throw new System.NotImplementedException();
        }

        public void LoadAllData()
        {
            throw new System.NotImplementedException();
        }

        public void SaveSingleData(string key, string data)
        {
            throw new System.NotImplementedException();
        }

        public void SaveGroupData(Dictionary<string, string> dataCollection)
        {
            var Path = System.IO.Path.Combine(Application.persistentDataPath + Date + ".txt");
            
            Debug.Log("File save in: " + Path);

            StreamWriter _writer = new(Path, true);

            _writer.WriteLine(SessionId, Encoding.UTF8);
            
            foreach (var element in dataCollection)
            {
                var stringToSave = element.Key + ": " + element.Value;
                Debug.Log(stringToSave);
                _writer.WriteLine(stringToSave, Encoding.UTF8);
            }
            _writer.Close();
        }
    }
}