using Leopotam.Ecs;
using AteroidsECS.Components.Player;
using AteroidsECS.Events.Player.Shoot;

namespace AteroidsECS.Systems.Player
{
    public class PlayerShootSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerShootComponent> _filterPlayer;
        private EcsFilter<FirstWeaponShootEvent> _firstWeaponfilter;
        private EcsFilter<SecondWeaponShootEvent> _secondWeaponfilter;

        public void Run()
        {
            foreach (var i in _filterPlayer)
            {
                ref var shootComponent = ref _filterPlayer.Get1(i);
                
                TryShootByEvent(_firstWeaponfilter, ref shootComponent);
                TryShootByEvent(_secondWeaponfilter, ref shootComponent);
            }
        }
        
        private void TryShootByEvent<TIEvent>(EcsFilter<TIEvent> weaponFilter, ref PlayerShootComponent shootComponent) where TIEvent : struct, IShootEvent
        {
            foreach (var i in weaponFilter)
            {
                ref var component = ref weaponFilter.Get1(i);
                
                shootComponent.Shoot(component);
            }
        }
    }
}