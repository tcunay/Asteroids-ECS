﻿using Leopotam.Ecs;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Shoot;
using AteroidsECS.Factories;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponsSystems : IEntitySystems
    {
        public WeaponsSystems(EcsWorld world, PrefabFactory factory)
        {
            UpdateSystems = new EcsSystems(world)
                .Add(new WeaponShootEventSystem()).OneFrame<DefaultWeaponShootEvent>().OneFrame<LaserWeaponShootEvent>()
                .Add(new BulletShootSystem()).Inject(factory);
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
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