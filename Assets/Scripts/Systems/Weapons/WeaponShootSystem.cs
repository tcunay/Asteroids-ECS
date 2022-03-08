﻿using Leopotam.Ecs;
using AteroidsECS.Components.Player;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Player.Shoot;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerShootComponent> _filterPlayer;
        private EcsFilter<FirstWeaponShootEvent> _firstWeaponfilter;
        private EcsFilter<SecondWeaponShootEvent> _secondWeaponfilter;
        private EcsFilter<DefaultBulletComponent> _defaultBulletComponent;

        public void Run()
        {
            foreach (var i in _filterPlayer)
            {
                ref var shootComponent = ref _filterPlayer.Get1(i);
                
                TryShootByEvent(_firstWeaponfilter, ref shootComponent);
                TryShootByEvent(_secondWeaponfilter, ref shootComponent);
            }

            foreach (var i in _defaultBulletComponent)
            {
                ref var bullet = ref _defaultBulletComponent.Get1(i);
                bullet.Run();
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