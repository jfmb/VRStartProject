using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody handleRigidBody;
    [SerializeField] private GameObject handleDetector;
    [SerializeField] private float doorMinDegrees;
    [SerializeField] private float doorMaxDegrees;
    [SerializeField] private HingeJoint doorJoint;
    [SerializeField] private GameObject realLock;
    [SerializeField] private GameObject fakeLock;
    [SerializeField] private Lock doorLock;
    
    private void Start()
    {
        SetDoorMaxLimitTo(doorMinDegrees);

        fakeLock.SetActive(false);
    }

    private void SetDoorMaxLimitTo(float newValue)
    {
        var limits = doorJoint.limits;
        limits.max = newValue;
        doorJoint.limits = limits;
    }
    
    public void OpenDoor()
    {
        handleDetector.SetActive(false);

        SetHandleConstraintsTo(RigidbodyConstraints.None);
        
        SetDoorMaxLimitTo(doorMaxDegrees);
        
        SetLockObjectWith(false);
    }

    private void SetLockObjectWith(bool newValue)
    {
        if (!realLock)
        {
            return;
        }

        realLock.SetActive(newValue);
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
        
        StartCoroutine(EnableHandleDetectorAfterSeconds());
    }

    IEnumerator EnableHandleDetectorAfterSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        handleDetector.SetActive(true);
    } 
}