using Leopotam.Ecs;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Shoot;
using AteroidsECS.Factories;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponsSystems : IEntitySystems
    {
        public WeaponsSystems(EcsWorld world, PrefabFactory factory)
        {
            var weaponSootEventSystem = new WeaponShootEventSystem();
            var bulletSystem = new BulletShootSystem();
            var laserSystem = new LaserShootSystem();

            InitSystems = new EcsSystems(world).Add(laserSystem).Inject(factory);
            
            UpdateSystems = new EcsSystems(world)
                .Add(weaponSootEventSystem).OneFrame<BulletWeaponShootEvent>().OneFrame<LaserWeaponShootEvent>()
                .Add(bulletSystem).Add(laserSystem).Inject(factory);
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }

    public class LaserShootSystem : IEcsInitSystem, IEcsRunSystem
    {
        //private EcsFilter<LaserWeaponComponent> _defaultBulletComponent;
        private PrefabFactory _prefabFactory;

        public void Init()
        {
            //throw new System.NotImplementedException();
        }

        public void Run()
        {
            //throw new System.NotImplementedException();
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