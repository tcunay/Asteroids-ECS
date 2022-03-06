using AteroidsECS.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.Components.Weapon
{
    public struct DefaultWeaponComponent : IWeaponComponent
    {
        private readonly EcsWorld _world;
        private readonly DefaultWeaponData _defaultWeaponData;
        private readonly Transform _spawnPoint;
        private readonly Vector2 _direction;

        public DefaultWeaponComponent(EcsWorld world, DefaultWeaponData defaultWeaponData, Transform spawnPoint, Vector2 direction)
        {
            _world = world;
            _defaultWeaponData = defaultWeaponData;
            _spawnPoint = spawnPoint;
            _direction = direction;
        }

        public void Shoot()
        {
            var bullet = _world.NewEntity();
            bullet.Get<DefaultBulletComponent>().Init(_defaultWeaponData, _spawnPoint, _direction);
        }
        
        
    }
}