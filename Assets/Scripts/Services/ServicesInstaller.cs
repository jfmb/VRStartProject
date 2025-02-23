using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Services.Adapters;
using DefaultNamespace.Services.Adapters.PermanentDataManagement;
using DefaultNamespace.Services.Analytics;
using DefaultNamespace.Services.Interfaces;
using ScriptableObjects.Scripts.Ids;
using Services.Counters;
using UnityEngine;
using Services.EventQueue;
using Services.EventQueue.Events.ScriptableObjects;

namespace Services
{
    public class ServicesInstaller : MonoBehaviour
    {
        [SerializeField] private EventId nextSceneEventId;
        [SerializeField] private SceneId nextSceneId;
        private void Awake()
        {
            var countersProvider = new CountersProvider();
            ServiceLocator.RegisterService(countersProvider);
            
            var sceneLoader = new SceneLoaderWithSceneNameAdapter();
            ServiceLocator.RegisterService<ISceneLoader>(sceneLoader);

            var analyticsStorage = new AnalyticsStorage();
            ServiceLocator.RegisterService(analyticsStorage);

            SetupDataManagement();

            
        }
        
        private void SetupDataManagement()
        {
            
            if (Application.platform == RuntimePlatform.Android)
            {
                var oculusPermanentDataStorage = new OculusFilePermanentDataManagementAdapter();
                ServiceLocator.RegisterService<IPermanentDataManagement>(oculusPermanentDataStorage);
                return;
            }
//            var permanentDataStorage = new PlayerPrefsPermanentDataManagementAdapter();

            var editorPermanentDataStorage = new EditorFilePermanentDataManagementAdapter();
            ServiceLocator.RegisterService<IPermanentDataManagement>(editorPermanentDataStorage);
        }
        
        private void Start()
        {
            StartCoroutine(StartSceneAfterSeconds());
        }

        private IEnumerator StartSceneAfterSeconds()
        {
            yield return new WaitForSeconds(1f);
            var args = new StringEventData(nextSceneId.Id);
            ServiceLocator.GetService<EventQueue.EventQueue>().EnqueueEvent(nextSceneEventId, args);
        }
    }
}