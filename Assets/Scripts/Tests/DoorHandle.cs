using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    private bool _isUnlocked;
    [SerializeField] private HingeJoint hinge;
    [SerializeField] private DoorChecker doorChecker;

    private float _seconds;
    private Quaternion _initialRotation;

    private void Start()
    {
        _initialRotation = transform.localRotation;
    }    
    
    void Update()
    {
        _seconds += Time.deltaTime;
        // if (!_isUnlocked && hinge.angle <= hinge.limits.min + 5f)
        // {
        //     _isUnlocked = true;
        //     doorChecker.IsLocked = false;
        //     doorChecker.TryToOpenDoor();
        //     Debug.Log("My debug: door is unlocked!");
        // }

        if (_seconds >= 1)
        {
            Debug.Log("My debug: handle position: " + gameObject.transform.localPosition);
            Debug.Log("My debug: handle rotation: " + gameObject.transform.localRotation);

            _seconds = 0f;
        }
    }

    public void ResetRotation()
    {
        transform.localRotation = _initialRotation;
    }
}
