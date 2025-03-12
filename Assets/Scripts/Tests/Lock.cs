using System.Collections;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private HingeJoint hingeJ;
    [SerializeField] private KeyDetector keyDetectorOpen;
    [SerializeField] private KeyDetector keyDetectorClose;
    [SerializeField] private DoorHandleDetector handleDetector;

    private bool _isKeyOnLock;
    private bool _isLockOpen;
    private bool _isFirstTime;
    
    private Rigidbody _keyRB;

    private void Start()
    {
        if (!handleDetector)
        {
            Debug.Log("No handle in inspector.");
            return;
        }
        handleDetector.SetIsLockedWith(true);
    }

    public void InjectHandleDetector(DoorHandleDetector hD)
    {
        if (!hD)
        {
            return;
        }
        
        handleDetector = hD;
    }
    
    public void SetupLock(Rigidbody newKeyRB)
    {

        _keyRB = newKeyRB;
        hingeJ.connectedBody = _keyRB;

        _isKeyOnLock = true;

        _isFirstTime = true;
        
        keyDetectorOpen.SetColliderWithValue(true);
        keyDetectorClose.SetColliderWithValue(true);
    }

    public void SetLockOpenWith(bool newValue)
    {
        if (!_isKeyOnLock)
        {
            return;
        }

        if (_isFirstTime)
        {
            _isFirstTime = false;
            return;
        }
        
        _isLockOpen = newValue;
        Debug.Log("My debug: door lock is open -> " + _isLockOpen);
        DoThingsIfLockIsOpen();
    }

    private void DoThingsIfLockIsOpen()
    {
        if (!_isLockOpen)
        {
            _keyRB.constraints = RigidbodyConstraints.None;
            hingeJ.connectedBody = null;
            handleDetector.SetIsLockedWith(true);

            return;
        }
        
        handleDetector.SetIsLockedWith(false);
    }

    public void ResetLock()
    {
        _isKeyOnLock = true;

        _isFirstTime = true;
        keyDetectorOpen.SetColliderWithValue(false);
        keyDetectorClose.SetColliderWithValue(false);
    }

    public void MakeKeyKinematicWith(bool newValue)
    {
        if (newValue)
        {
            StartCoroutine(EnableKeyAfterSeconds());
            return;
        }
        _keyRB.gameObject.SetActive(false);
    }

    IEnumerator EnableKeyAfterSeconds()
    {
        _keyRB.gameObject.SetActive(true);
        _keyRB.constraints = RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(1f);
        _keyRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePosition;
    }
}
