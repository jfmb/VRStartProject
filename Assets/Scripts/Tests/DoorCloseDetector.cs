using UnityEngine;

public class DoorCloseDetector : MonoBehaviour
{
    [SerializeField] private DoorChecker doorChecker;
    private bool _doorIsClosed = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Door"))
        {
            return;
        }
        
        if (_doorIsClosed)
        {
            return;
        }

        _doorIsClosed = true;
            
        doorChecker.CloseDoor();
        Debug.Log("My debug: door is closed");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Door"))
        {
            return;
        }

        _doorIsClosed = false;

        Debug.Log("My debug: door is open");
    }
}
