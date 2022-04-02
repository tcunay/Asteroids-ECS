using System;
using Leopotam.Ecs;
using AteroidsECS.Components.Player;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Shoot;

namespace AteroidsECS.Systems.Weapons
{
    public class WeaponShootEventSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerShootComponent> _filterPlayer;
        private EcsFilter<BulletWeaponShootEvent> _defaultWeaponfilter;
        private EcsFilter<LaserWeaponShootEvent> _laserWeaponfilter;

        public void Run()
        {
            foreach (var i in _filterPlayer)
            {
                ref var shootComponent = ref _filterPlayer.Get1(i);

                TryShoot(_defaultWeaponfilter, ref shootComponent);
                TryShoot(_laserWeaponfilter, ref shootComponent);
            }
        }

        private void TryShoot<TIEvent>(EcsFilter<TIEvent> weaponFilter, ref PlayerShootComponent shootComponent)
            where TIEvent : struct, IShootEvent
        {
            foreach (var i in weaponFilter)
                Shoot(weaponFilter.IncludedTypes[0], ref shootComponent);
        }
        
        private void Shoot(Type shootType, ref PlayerShootComponent shootComponent)
        {
            if (shootType == typeof(BulletWeaponShootEvent))
                shootComponent.BuletWeapon.Shoot();
            else if (shootType == typeof(LaserWeaponShootEvent))
                shootComponent.LaserWeapon.Shoot();
            else
                throw new InvalidOperationException();
        }
    }
}