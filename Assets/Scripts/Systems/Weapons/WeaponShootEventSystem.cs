using Leopotam.Ecs;
using AteroidsECS.Components.Player;
using AteroidsECS.Events.Shoot;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponShootEventSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerShootComponent> _filterPlayer;
        private EcsFilter<DefaultWeaponShootEvent> _defaultWeaponfilter;
        private EcsFilter<LaserWeaponShootEvent> _laserWeaponfilter;

        public void Run()
        {
            foreach (var i in _filterPlayer)
            {
                ref var shootComponent = ref _filterPlayer.Get1(i);

                TryShootByEvent(_defaultWeaponfilter, ref shootComponent);
                TryShootByEvent(_laserWeaponfilter, ref shootComponent);
            }
        }

        private void TryShootByEvent<TIEvent>(EcsFilter<TIEvent> weaponFilter, ref PlayerShootComponent shootComponent)
            where TIEvent : struct, IShootEvent
        {
            foreach (var i in weaponFilter)
            {
                ref var component = ref weaponFilter.Get1(i);

                shootComponent.Shoot(component);
            }
        }
    }
}