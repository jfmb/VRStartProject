using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private HingeJoint hingeJ;
    [SerializeField] private KeyDetector keyDetectorOpen;
    [SerializeField] private KeyDetector keyDetectorClose;

    private bool _isKeyOnLock;

    private bool _isLockOpen;

    private bool _isFirstTime;
    
    private Rigidbody _keyRB;
    
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
        
        Debug.Log("My debug: door is open -> " + _isLockOpen);
        _isLockOpen = newValue;
        DoThingsIfLockIsOpen();
    }

    private void DoThingsIfLockIsOpen()
    {
        if (!_isLockOpen)
        {
            _keyRB.constraints = RigidbodyConstraints.None;
            hingeJ.connectedBody = null;

            return;
        }
    }

    public void ResetLock()
    {
        _isKeyOnLock = true;

        _isFirstTime = true;
        keyDetectorOpen.SetColliderWithValue(false);
        keyDetectorClose.SetColliderWithValue(false);
    }
}
