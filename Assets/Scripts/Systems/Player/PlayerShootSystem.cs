using Leopotam.Ecs;
using AteroidsECS.Components.Player;

namespace AteroidsECS.Systems.Player
{
    public class PlayerShootSystem : IEcsRunSystem
    {
        private EcsFilter<FirstWeaponEvent> _firstWeaponfilter;
        private EcsFilter<SecondWeaponEvent> _secondWeaponfilter;
        private EcsFilter<PlayerShootComponent> _filterPlayer;

        public void Run()
        {
            foreach (var i in _filterPlayer)
            {
                ref var shootComponent = ref _filterPlayer.Get1(i);
                
                TryShootByEvent(_firstWeaponfilter, ref shootComponent);
                TryShootByEvent(_secondWeaponfilter, ref shootComponent);
            }
            
        }
        
        private void TryShootByEvent<TIEvent>(EcsFilter<TIEvent> weaponFilter, ref PlayerShootComponent shootComponent) where TIEvent : struct, IEvent
        {
            foreach (var i in weaponFilter)
            {
                ref var component = ref weaponFilter.Get1(i);
                
                shootComponent.Shoot(component);
            }
        }
    }
}