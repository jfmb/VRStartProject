using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    [SerializeField] private HingeJoint handleJoint;
    [SerializeField] private Rigidbody doorRigidBody;
    [SerializeField] private Rigidbody handleRigidBody;
    [SerializeField] private GameObject handleDetector;
    [SerializeField] private DoorHandle doorHandle;
    [SerializeField] private HingeJoint doorJoint;

    private void Start()
    {
        SetDoorMaxLimitTo(0f);
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
        
        SetDoorMaxLimitTo(100f);
    }

    private void SetHandleConstraintsTo(RigidbodyConstraints newConstraints)
    {
        handleRigidBody.constraints = newConstraints;
    }
    
    public void CloseDoor()
    {
        var limits = doorJoint.limits;
        limits.max = 0f;
        doorJoint.limits = limits;
        
        SetHandleConstraintsTo(RigidbodyConstraints.FreezePositionZ);
        StartCoroutine(EnableHandleDetectorAfterSeconds());
    }

    IEnumerator EnableHandleDetectorAfterSeconds()
    {
        yield return new WaitForSeconds(05f);
        handleDetector.SetActive(true);
    } 
}