using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    private HingeJoint doorHinge;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool canOpen = false;

    void Start()
    {
        doorHinge = GetComponent<HingeJoint>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Desactivamos la interacción física al principio
        grabInteractable.enabled = false;
        rb.isKinematic = true; 
    }

    public void UnlockDoor()
    {
        canOpen = true;
        grabInteractable.enabled = true; // Ahora se puede empujar con la mano
        rb.isKinematic = false; // Permitir que la puerta se mueva con física
    }
}

