using Leopotam.Ecs;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Shoot;
using AteroidsECS.Factories;
using UnityEngine;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponsSystems : IEntitySystems
    {
        public WeaponsSystems(EcsWorld world, PrefabFactory factory)
        {
            var bulletSystem = new BulletShootSystem();
            var laserSystem = new LaserShootSystem();

            InitSystems = new EcsSystems(world).Add(laserSystem).Inject(factory);
            
            UpdateSystems = new EcsSystems(world)
                .Add(bulletSystem).Add(laserSystem).Inject(factory);
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }

    public class LaserShootSystem : IEcsRunSystem
    {
        private EcsFilter<LaserBulletComponent> _laserBulletComponent;

        public void Run()
        {
            foreach (var i in _laserBulletComponent)
            {
                ref var bulet = ref _laserBulletComponent.Get1(i);
                if (Time.time - bulet.CreateTime <= bulet.MaxLifetime)
                    bulet.Run();
                else
                    bulet.TurnOff();
            }
        }
    }

    public class BulletShootSystem : IEcsRunSystem
    {
        private EcsFilter<DefaultBulletComponent> _defaultBulletComponent;
        private PrefabFactory _prefabFactory;

        public void Run()
        {
            foreach (var i in _defaultBulletComponent)
            {
                ref var bullet = ref _defaultBulletComponent.Get1(i);
                bullet.Run();

                if (bullet.IsLifeTimeEnded)
                {
                    bullet.Destroy();
                    var bulletEntity = _defaultBulletComponent.GetEntity(i);
                    bulletEntity.Destroy();
                }
                    
            }
        }
    }
}