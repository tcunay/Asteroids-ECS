using AteroidsECS.Events.Player.Shoot;
using AteroidsECS.Factories;
using AteroidsECS.Systems.Player;
using Leopotam.Ecs;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponsSystems : IEntitySystems
    {
        public WeaponsSystems(EcsWorld world, PrefabFactory factory)
        {
            UpdateSystems = new EcsSystems(world).Add(new WeaponShootSystem()).OneFrame<FirstWeaponShootEvent>().OneFrame<SecondWeaponShootEvent>();
        }
        
        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }
}