using UnityEngine;
using AteroidsECS.MonoBehaviours.MonoEntities;

namespace AteroidsECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class DefaultWeaponData : ScriptableObject, IBulletBase
    {
        [SerializeField] private MonoEntity _defaultBulletPrefab;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _lifetime;

        public MonoEntity DefaultBulletPrefab => _defaultBulletPrefab;
        public int Damage => _damage;
        public float Speed => _speed;
        public float MaxLifetime => _lifetime;
    }
}