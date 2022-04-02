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

                TryShoot(ref shootComponent, _defaultWeaponfilter, _laserWeaponfilter);
            }
        }

        private void TryShoot(ref PlayerShootComponent shootComponent, params EcsFilter[] weaponFilters)
        {
            foreach (var weaponFilter in weaponFilters)
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