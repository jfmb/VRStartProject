using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magnet : MonoBehaviour
{
    [SerializeField] private XRInteractionManager interactionManager;
    [SerializeField] private GameObject magnet;
    [SerializeField] private GameObject objectToInstantiate;

    [SerializeField] private Lock lockForKey;
    
    private bool _keyIsPresent;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("My debug: magnet detected " + other.tag );
        if (_keyIsPresent)
        {
            return;
        }
        
        var otherGameObject = other.gameObject;
        if (!otherGameObject.CompareTag("Key"))
        {
            return;
        }
        Debug.Log("My debug: key detected");
        
        ForceDropObject(other.gameObject);
//        StartCoroutine(DisableIsKinematicAfterOneFrame(otherGameObject));

        var objectToDestroy = otherGameObject.transform.parent;

        var newObject = Instantiate(objectToInstantiate);
        newObject.transform.position = gameObject.transform.position;
        newObject.transform.rotation = gameObject.transform.rotation;
        
        Destroy(objectToDestroy.gameObject);
        _keyIsPresent = true;

        var rb = newObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        lockForKey.SetupLock(rb);
    }

    private void ForceDropObject(GameObject otherGameObject)
    {
        var grabInteractable = otherGameObject.GetComponentInParent<XRGrabInteractable>();

        if (!grabInteractable)
        {
            return;
        }
        
        grabInteractable.transform.position = magnet.transform.position;
        
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
        if (!other.CompareTag("Key"))
        {
            return;
        }
        
        _keyIsPresent = false;
    }

    IEnumerator DisableIsKinematicAfterOneFrame(GameObject otherGameObject)
    {
        otherGameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1f);
        otherGameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }
}
