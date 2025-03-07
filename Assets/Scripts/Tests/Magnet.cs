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
        if (_keyIsPresent)
        {
            return;
        }
        Debug.Log("My debug: magnet detected " + other.tag );
        
        var otherGameObject = other.gameObject;
        if (!otherGameObject.CompareTag("Key"))
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
        
        Debug.Log("My debug: key exited the magnet ");

        StartCoroutine(ResetMagnetAndLockAfterSeconds());
    }

    IEnumerator ResetMagnetAndLockAfterSeconds()
    {
        yield return new WaitForSeconds(2f);
        _keyIsPresent = false;

        lockForKey.ResetLock();
    }
}
