using AteroidsECS.MonoBehaviours.MonoEntities;
using UnityEngine;

namespace AteroidsECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class LaserWeaponData : ScriptableObject
    {
        [SerializeField] private LineRendererMonoEntity _laserBulletPrefab;
        [SerializeField] private float _distance;
        [SerializeField] private float _lifetime;

        public LineRendererMonoEntity LaserBulletPrefab => _laserBulletPrefab;
        public float Distance => _distance;
        public float LifeTime => _lifetime;
    }
}