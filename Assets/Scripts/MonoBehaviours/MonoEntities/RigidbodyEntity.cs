using UnityEngine;

namespace AteroidsECS.MonoBehaviours.MonoEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyEntity : MonoEntity
    {
        public Rigidbody2D Rigidbody { get; private set; }

        public override void Init()
        {
            base.Init();
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}