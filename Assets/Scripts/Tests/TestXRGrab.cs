using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestXRGrab : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable parentInteractable;
    [SerializeField] private Rigidbody rb;

    private bool _isClosed = true;
    private bool _isBlocked = true;
    void Start()
    {
        XRGrabInteractable grabInt;
        HingeJoint joint;
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
        
        _isBlocked = false;
        // if (!DoorCanBeOpened())
        // {
        //     return;
        // }
        // other.GetComponent<Joint>().connectedBody = rb; 
    }

    private bool DoorCanBeOpened()
    {
        return _isClosed && !_isBlocked;
    }
}
