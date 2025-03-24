using System.Collections.Generic;
using Adapters.DoThingsAfterMagnetObject;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Transform transformToMagnetObject;
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Lock lockForKey;
    [SerializeField] private string objectTag;

    [SerializeField] private List<DoThingsAfterMagnetObject> thingsToDoAfterMagnetObject;
    
    private bool _objectIsPresent;

    private void Start()
    {
        if (!transformToMagnetObject)
        {
            transformToMagnetObject = transform;
        }
        
        foreach (var element in thingsToDoAfterMagnetObject)
        {
            element.Setup();
        }       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_objectIsPresent)
        {
            return;
        }
        Debug.Log("My debug: magnet detected " + other.tag );
        
//        if (!other.gameObject.CompareTag(objectTag))
        if (!IsTheCorrectObject(other.gameObject))
        {
            return;
        }
        
        _objectIsPresent = true;
        
        ForceDropObject(other.gameObject);
        Destroy(other.gameObject);
        
        var rb= InstantiateNewObject();
        SetupLock(rb);

        foreach (var element in thingsToDoAfterMagnetObject)
        {
            element.Execute();
        }
    }

    private bool IsTheCorrectObject(GameObject otherGameObject)
    {
        return otherGameObject.CompareTag(objectTag);
    }
    
    private void ForceDropObject(GameObject otherGameObject)
    {
        var grabInteractable = otherGameObject.GetComponent<XRGrabInteractable>();
        
        if (!grabInteractable)
        {
            return;
        }

        var interactionManager = grabInteractable.interactionManager;
        
        grabInteractable.transform.position = transformToMagnetObject.position;
        
        var interactor = grabInteractable.firstInteractorSelecting;

        if (interactor == null)
        {
            return;
        }
        interactionManager.CancelInteractorSelection(interactor);
        
        Debug.Log("My debug: Key is dropped");
    }
    
    
    private Rigidbody InstantiateNewObject()
    {
        var newObject = Instantiate(objectToInstantiate);
   
        newObject.transform.position = transformToMagnetObject.position;
        newObject.transform.rotation = transformToMagnetObject.rotation;
        
        var rb = newObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        
        return rb;
    }

    
    private void SetupLock(Rigidbody rb)
    {
        if (!lockForKey)
        {
            return;
        }
        
        lockForKey.SetupLock(rb);
    }



    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(objectTag))
        {
            return;
        }
        
        Debug.Log("My debug: key exited the magnet ");

        _objectIsPresent = false;
        
        ResetLock();

        foreach (var element in thingsToDoAfterMagnetObject)
        {
            element.Setup();
        }
    }

    private void ResetLock()
    {
        if (!lockForKey)
        {
            return;
        }

        lockForKey.ResetLock();
    }
}
