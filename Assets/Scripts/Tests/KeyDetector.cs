using UnityEngine;
using UnityEngine.Assertions;

public class KeyDetector : MonoBehaviour
{
    [SerializeField] private bool isOpenLock;
    
    private Lock _lockForKey;

    private Collider _keyDetectorCollider;
    
    
    private void Start()
    {
        Assert.IsNotNull(transform.parent.GetComponent<Lock>(), "No Lock script in parent");
        
        _lockForKey = transform.parent.GetComponent<Lock>();
        
        _keyDetectorCollider = gameObject.GetComponent<Collider>();
        _keyDetectorCollider.enabled = false;
    }

    public void SetColliderWithValue(bool newValue)
    {
        _keyDetectorCollider.enabled = newValue;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("KeyDetector"))
        {
            return;
        }
        _lockForKey.SetLockOpenWith(isOpenLock);
    }
}
