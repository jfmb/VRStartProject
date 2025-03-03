using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody handleRigidBody;
    [SerializeField] private GameObject handleDetector;
    [SerializeField] private float doorMinDegrees;
    [SerializeField] private float doorMaxDegrees;
    [SerializeField] private HingeJoint doorJoint;

    private void Start()
    {
        SetDoorMaxLimitTo(doorMinDegrees);
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
    }

    private void SetHandleConstraintsTo(RigidbodyConstraints newConstraints)
    {
        handleRigidBody.constraints = newConstraints;
    }
    
    public void CloseDoor()
    {
        SetDoorMaxLimitTo(doorMinDegrees);
        
        SetHandleConstraintsTo(RigidbodyConstraints.FreezePositionZ);
        StartCoroutine(EnableHandleDetectorAfterSeconds());
    }

    IEnumerator EnableHandleDetectorAfterSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        handleDetector.SetActive(true);
    } 
}