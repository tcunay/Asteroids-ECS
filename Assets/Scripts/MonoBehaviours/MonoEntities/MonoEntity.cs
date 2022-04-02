using UnityEngine;

namespace AteroidsECS.MonoBehaviours.MonoEntities
{
    [RequireComponent(typeof(Transform))]
    public class MonoEntity : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        public virtual void Init()
        {
            Transform = GetComponent<Transform>();
        }

        public void Destroy(float destroyTime = 0)
        {
            Destroy(gameObject, destroyTime);
        }
    }
}