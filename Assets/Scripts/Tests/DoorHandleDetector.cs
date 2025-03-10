using UnityEngine;

public class DoorHandleDetector : MonoBehaviour
{
    [SerializeField] private DoorChecker doorChecker;
    
    private bool _isLocked;

    public void SetIsLockedWith(bool newValue)
    {
        _isLocked = newValue;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Handle"))
        {
            return;
        }

        if (_isLocked)
        {
            return;
        }
        
        doorChecker.OpenDoor();
    }
}

