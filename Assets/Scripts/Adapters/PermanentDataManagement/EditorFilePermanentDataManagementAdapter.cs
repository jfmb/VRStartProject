using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultNamespace.Services.Interfaces;
using UnityEngine;

namespace DefaultNamespace.Services.Adapters.PermanentDataManagement
{
    public class EditorFilePermanentDataManagementAdapter: IPermanentDataManagement
    {
        private static readonly string SessionId = System.DateTime.Now.ToString("\nyyyy/MM/dd-HH:mm:ss");
        private static readonly string Date = System.DateTime.Now.ToString("yyyyMMdd");

        private static readonly string Path = System.IO.Path.Combine(Application.dataPath, "StreamingAssets/Report" + Date + ".txt");

        private readonly StreamWriter _writer = new(Path, true);
        
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
            Debug.Log("File save in: " + Path);

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