using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magnet : MonoBehaviour
{
    [SerializeField] private XRInteractionManager interactionManager;
    [SerializeField] private Transform transformToMagnet;
    [SerializeField] private GameObject objectToInstantiate;

    [SerializeField] private Lock lockForKey;
    [SerializeField] private string objectTag;
    
    private bool _keyIsPresent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_keyIsPresent)
        {
            return;
        }
        Debug.Log("My debug: magnet detected " + other.tag );
        
        var otherGameObject = other.gameObject;
        if (!otherGameObject.CompareTag(objectTag))
        {
            return;
        }
        
        _keyIsPresent = true;

        Debug.Log("My debug: key detected");
        
        ForceDropObject(other.gameObject);
        
        var newObject = Instantiate(objectToInstantiate);
   
        newObject.transform.position = gameObject.transform.position;
        newObject.transform.rotation = gameObject.transform.rotation;
        
        var objectToDestroy = otherGameObject.transform;
        Destroy(objectToDestroy.gameObject);
        
        var rb = newObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;

        if (!lockForKey)
        {
            return;
        }
        
        lockForKey.SetupLock(rb);
    }

    private void ForceDropObject(GameObject otherGameObject)
    {
        var grabInteractable = otherGameObject.GetComponentInParent<XRGrabInteractable>();

        if (!grabInteractable)
        {
            return;
        }
        
        grabInteractable.transform.position = transformToMagnet.position;
        
        var interactor = grabInteractable.firstInteractorSelecting;

        if (interactor == null)
        {
            return;
        }
        interactionManager.CancelInteractorSelection(interactor);
        
        Debug.Log("My debug: Key is dropped");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(objectTag))
        {
            return;
        }
        
        Debug.Log("My debug: key exited the magnet ");

        _keyIsPresent = false;
        
        if (!lockForKey)
        {
            return;
        }

        lockForKey.ResetLock();
    }
}
