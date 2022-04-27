using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.Components.Weapon
{
    public struct DefaultWeaponComponent : IWeaponComponent
    {
        private readonly EcsWorld _world;
        private readonly PrefabFactory _factory;
        private readonly DefaultWeaponData _defaultWeaponData;
        private readonly Transform _spawnPoint;
        private readonly Vector2 _direction;

        public DefaultWeaponComponent(EcsWorld world, PrefabFactory factory, DefaultWeaponData defaultWeaponData,
            Transform spawnPoint, Vector2 direction)
        {
            _world = world;
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
        public LaserWeaponComponent(LineRendererMonoEntity bullet)
        {
            Bullet = bullet;
        }

        private LineRendererMonoEntity Bullet { get; }

        public void Shoot(EcsEntity bullet)
        {
            bullet.Replace(new LaserBulletComponent(Bullet));
        }
    }
}