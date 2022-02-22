using UnityEngine;

namespace AteroidsECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class DefaultWeaponData : ScriptableObject
    {
        [SerializeField] private GameObject _defaultBulletPrefab;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _lifetime;

        public GameObject DefaultBulletPrefab => _defaultBulletPrefab;
        public int Damage => _damage;
        public float Speed => _speed;
        public float Lifetime => _lifetime;
    }
}