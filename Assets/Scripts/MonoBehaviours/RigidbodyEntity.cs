using UnityEngine;

namespace AteroidsECS.MonoBehaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyEntity : MonoEntity
    {
        public Rigidbody2D Rigidbody { get; private set; }
        
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}