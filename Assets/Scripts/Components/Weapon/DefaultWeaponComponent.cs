using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.Components.Weapon
{
    public struct DefaultWeaponComponent : IWeaponComponent
    {
        private readonly PrefabFactory _factory;
        private readonly DefaultWeaponData _defaultWeaponData;
        private readonly Transform _spawnPoint;
        private readonly Vector2 _direction;

        public DefaultWeaponComponent(DefaultWeaponData defaultWeaponData, PrefabFactory factory,
            Transform spawnPoint, Vector2 direction)
        {
            _factory = factory;
            _defaultWeaponData = defaultWeaponData;
            _spawnPoint = spawnPoint;
            _direction = direction;
        }

        public void Shoot(EcsEntity bullet)
        {
            bullet.Replace(new DefaultBulletComponent(_defaultWeaponData, _factory, _spawnPoint, _direction));
        }
    }

    public struct LaserWeaponComponent : IWeaponComponent
    {
        public LaserWeaponComponent(LaserWeaponData weaponData, PrefabFactory prefabFactory, Transform parent)
        {
            Bullet = prefabFactory.Create(weaponData.LaserBulletPrefab, parent);
        }

        private LineRendererMonoEntity Bullet { get; }

        public void Shoot(EcsEntity bullet)
        {
            Bullet.Init(bullet);
            bullet.Replace(new LaserBulletComponent(Bullet));
        }
    }
}