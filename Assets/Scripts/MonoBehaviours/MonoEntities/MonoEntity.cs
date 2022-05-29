using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.MonoBehaviours.MonoEntities
{
    [RequireComponent(typeof(Transform))]
    public class MonoEntity : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        public EcsEntity Entity { get; private set; }

        public virtual void Init(EcsEntity entity)
        {
            Transform = GetComponent<Transform>();
            Entity = entity;
        }

        public void Destroy(float destroyTime = 0)
        {
            Destroy(gameObject, destroyTime);
        }
    }
}