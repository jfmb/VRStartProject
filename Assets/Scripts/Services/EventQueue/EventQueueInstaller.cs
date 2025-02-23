using System.Collections;
using System.Collections.Generic;
using Services.EventQueue;
using UnityEngine;

public class EventQueueInstaller : MonoBehaviour
{
    [SerializeField] private EventQueue eventQueue;

    private void Awake()
    {
        DontDestroyOnLoad(eventQueue.gameObject);
        ServiceLocator.RegisterService(eventQueue);
    }
}
