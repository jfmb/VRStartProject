using UnityEngine;

namespace Adapters.DoThingsAfterMagnetObject
{
    public class ChangeTheLockCentralCylinder: DoThingsAfterMagnetObject
    {
        [SerializeField] private GameObject lockGameObject;
        [SerializeField] private GameObject otherLockGameObject;
        
        public override void Setup()
        {
            lockGameObject.SetActive(true);
            otherLockGameObject.SetActive(false);
        }

        public override void Execute()
        {
            lockGameObject.SetActive(false);
            otherLockGameObject.SetActive(true);
        }
    }
}