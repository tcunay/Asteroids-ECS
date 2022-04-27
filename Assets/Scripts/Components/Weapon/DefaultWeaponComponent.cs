using AteroidsECS.Factories;
using AteroidsECS.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.Components.Weapon
{
    public struct DefaultWeaponComponent : IWeaponComponent
    {
        private readonly EcsWorld _world;
        private readonly PrefabFactory _factory;
        private readonly WeaponData _weaponData;
        private readonly Transform _spawnPoint;
        private readonly Vector2 _direction;

        public DefaultWeaponComponent(EcsWorld world, PrefabFactory factory, WeaponData weaponData,
            Transform spawnPoint, Vector2 direction)
        {
            _world = world;
            _factory = factory;
            _weaponData = weaponData;
            _spawnPoint = spawnPoint;
            _direction = direction;
        }

        public void Shoot()
        {
            var bullet = _world.NewEntity();
            bullet.Replace(new DefaultBulletComponent(_weaponData, _factory, _spawnPoint, _direction));
        }
    }
}