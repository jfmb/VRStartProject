using UnityEngine;

namespace Adapters.DoThingsAfterMagnetObject
{
    public abstract class DoThingsAfterMagnetObject: MonoBehaviour
    {
        public abstract void Setup();
        public abstract void Execute();
    }
}