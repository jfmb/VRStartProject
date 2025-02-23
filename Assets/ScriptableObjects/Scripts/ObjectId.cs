using UnityEngine;

namespace ScriptableObjects.Scripts.Ids
{
//    [CreateAssetMenu(fileName = "ObjectId", menuName = "Ids/Create ObjectId", order = 0)]
    public abstract class ObjectId : ScriptableObject
    {
        [SerializeField] private string id;

        public string Id => id;
    }
}