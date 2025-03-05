using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private HingeJoint hingeJ;

    private bool _isKeyOnLock;

    private bool _isLockOpen;

    private bool _isFirstTime = true;
    
    private Rigidbody _keyRB;
    public void SetupLock(Rigidbody newKeyRB)
    {
        _keyRB = newKeyRB;
        
        hingeJ.connectedBody = _keyRB;
//        transform.parent = _keyRB.transform;
        _isKeyOnLock = true;
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
    
}
