using UnityEngine;

namespace AteroidsECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private Rigidbody2D _prefab;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        public Rigidbody2D Prefab => _prefab;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;
    }
}