using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    [SerializeField] private bool isOpenLock;
    [SerializeField] private Lock lockForKey;
    
    
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("My debug: is a key detector?" + other.gameObject.tag + " object name: " + other.gameObject.name);
        if (!other.gameObject.CompareTag("KeyDetector"))
        {
            return;
        }
        lockForKey.SetLockOpenWith(isOpenLock);
    }
}
