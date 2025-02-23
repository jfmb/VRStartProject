using System.Collections.Generic;
using DefaultNamespace.Services.Interfaces;
using UnityEngine;

namespace DefaultNamespace.Services.Adapters.PermanentDataManagement
{
    public class PlayerPrefsPermanentDataManagementAdapter: IPermanentDataManagement
    {
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
            PlayerPrefs.SetString(key, data);
        }

        public void SaveGroupData(Dictionary<string, string> dataCollection)
        {
            foreach (var element in dataCollection)
            {
                Debug.Log("Code: " + element.Key +" => " + element.Value);
                PlayerPrefs.SetString(element.Key, element.Value);
            }
        }
    }
}