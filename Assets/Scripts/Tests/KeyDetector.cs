using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    [SerializeField] private bool isOpenLock;
    [SerializeField] private Lock lockForKey;

    private Collider _keyDetectorCollider;
    
    
    private void Start()
    {
        _keyDetectorCollider = gameObject.GetComponent<Collider>();
        _keyDetectorCollider.enabled = false;
    }

    public void SetColliderWithValue(bool newValue)
    {
        _keyDetectorCollider.enabled = newValue;
    }
    
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
