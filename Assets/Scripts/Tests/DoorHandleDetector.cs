using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class DoorHandleDetector : MonoBehaviour
{
    [SerializeField] private DoorChecker doorChecker;

    [SerializeField] private bool isLocked; 
    
    void Start()
    {
        doorChecker.IsLocked = isLocked;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Handle"))
        {
            // if (other.gameObject.CompareTag("Door"))
            // {
            //     _isClosed = !_isClosed;
            // }
            return;
        }

        if (!isLocked)
        {
            return;
        }
        
        doorChecker.IsLocked = false;
        doorChecker.TryToOpenDoor();
    }
}

