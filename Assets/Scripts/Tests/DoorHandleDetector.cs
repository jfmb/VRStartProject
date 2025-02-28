using UnityEngine;

public class DoorHandleDetector : MonoBehaviour
{
    [SerializeField] private DoorChecker doorChecker;
    [SerializeField] private bool isLocked; 

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Handle"))
        {
            return;
        }

        if (isLocked)
        {
            return;
        }
        
        doorChecker.OpenDoor();
    }
}

