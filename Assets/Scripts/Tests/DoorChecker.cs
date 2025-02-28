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
    
    public bool IsLocked { get; set; }

    public bool IsClosed { get; set; }

    private void Start()
    {
        var limits = doorJoint.limits;
        limits.max = 0f;
        doorJoint.limits = limits;
    }
    
    public void TryToOpenDoor()
    {
        handleDetector.SetActive(false);

        handleRigidBody.constraints = RigidbodyConstraints.None;
        var limits = doorJoint.limits;
        limits.max = 100f;
        doorJoint.limits = limits;
    }

    public void CloseDoor()
    {
        var limits = doorJoint.limits;
        limits.max = 0f;
        doorJoint.limits = limits;
        
        handleDetector.SetActive(true);
        handleRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        
        IsClosed = true;
    }
}