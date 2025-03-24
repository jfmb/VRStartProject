using System.Collections;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody handleRigidBody;
    [SerializeField] private GameObject handleDetector;
    [SerializeField] private float doorMinDegrees;
    [SerializeField] private float doorMaxDegrees;
    [SerializeField] private HingeJoint doorJoint;
    [SerializeField] private GameObject fakeLock;
    [SerializeField] private Lock doorLock;

    [SerializeField] private GameObject invisibleWall;
    
    private GameObject _realLock;

    private void Start()
    {
        SetDoorMaxLimitTo(doorMinDegrees);
        fakeLock.SetActive(false);

        SetupThingsIfItHasLock();
    }

    private void SetDoorMaxLimitTo(float newValue)
    {
        var limits = doorJoint.limits;
        limits.max = newValue;
        doorJoint.limits = limits;
    }

    private void SetupThingsIfItHasLock()
    {
        if (!DoorHasLock())
        {
            return;
        }
        
        SetupTheRealLock();
        InjectHandleDetectorToLock();
    }
    
    
    private bool DoorHasLock()
    {
        return doorLock;
    }

    private void SetupTheRealLock()
    {
        _realLock = doorLock.transform.parent.gameObject;
        _realLock.SetActive(true);
    }
    
    private void InjectHandleDetectorToLock()
    {
        doorLock.InjectHandleDetector(handleDetector.GetComponent<DoorHandleDetector>());
    }
    
    public void OpenDoor()
    {
        handleDetector.SetActive(false);

        SetHandleConstraintsTo(RigidbodyConstraints.None);
        
        SetDoorMaxLimitTo(doorMaxDegrees);
        
        SetLockObjectWith(false);
        
        invisibleWall.SetActive(false);
    }

    private void SetLockObjectWith(bool newValue)
    {
        if (!_realLock)
        {
            return;
        }

        _realLock.SetActive(newValue);
        doorLock.MakeKeyKinematicWith(newValue);

        fakeLock.SetActive(!newValue);
    }
    
    private void SetHandleConstraintsTo(RigidbodyConstraints newConstraints)
    {
        handleRigidBody.constraints = newConstraints;
    }
    
    public void CloseDoor()
    {
        SetDoorMaxLimitTo(doorMinDegrees);
        
        SetHandleConstraintsTo(RigidbodyConstraints.FreezePositionZ);
        SetLockObjectWith(true);
        invisibleWall.SetActive(true);

        
        StartCoroutine(EnableHandleDetectorAfterFrame());
    }

    IEnumerator EnableHandleDetectorAfterFrame()
    {
        yield return new WaitForEndOfFrame();
        handleDetector.SetActive(true);
    } 
}