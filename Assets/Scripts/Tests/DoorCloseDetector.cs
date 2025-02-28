using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseDetector : MonoBehaviour
{
    [SerializeField] private DoorChecker doorChecker;
    private bool _doorIsClosed = true;

    private void Start()
    {
        doorChecker.IsClosed = _doorIsClosed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_doorIsClosed)
        {
            return;
        }
        
        doorChecker.IsClosed = true;
        _doorIsClosed = true;
            
        doorChecker.CloseDoor();
        Debug.Log("My debug: door is closed");
    }

    private void OnTriggerExit(Collider other)
    {
        _doorIsClosed = false;
        doorChecker.IsClosed = false;
        Debug.Log("My debug: door is open");
    }
}
