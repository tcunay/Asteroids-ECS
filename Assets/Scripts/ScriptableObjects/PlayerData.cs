using System;
using AteroidsECS.Components.Abstract;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.MonoBehaviours.MonoEntities;
using UnityEngine;

namespace AteroidsECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject, IMoveProperties
    {
        [SerializeField] private RigidbodyEntity _prefab;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        private void OnValidate()
        {
            if (_moveSpeed < 0)
            {
                _moveSpeed = 0;
                throw new InvalidOperationException(nameof(_moveSpeed));
            }
            
            if (_rotateSpeed < 0)
            {
                _rotateSpeed = 0;
                throw new InvalidOperationException(nameof(_rotateSpeed));
            }
                
        }

        public RigidbodyEntity Prefab => _prefab;
        public float MoveValue => _moveSpeed;
        public float RotateValue => _rotateSpeed;
    }
}