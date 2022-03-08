using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Shoot;
using UnityEngine;

namespace AteroidsECS.Components.Player
{
    public struct PlayerShootComponent
    {
        public void Init(IWeaponComponent bulletWeapon, IWeaponComponent laserWeapon, Transform shootPoint)
        {
            BuletWeapon = bulletWeapon;
            LaserWeapon = laserWeapon;
            ShootPoint = shootPoint;
        }

        public IWeaponComponent BuletWeapon { get; private set; }
        public IWeaponComponent LaserWeapon { get; private set; }
        private Transform ShootPoint { get; set; }
        
        public void Shoot(IShootEvent shootEvent)
        {
            switch (shootEvent)
            {
                case DefaultWeaponShootEvent _:
                    Shoot(BuletWeapon);
                    break;
                case LaserWeaponShootEvent _:
                    Shoot(LaserWeapon);
                    break;
            }
        }
        
        private void Shoot(IWeaponComponent weapon) => weapon.Shoot();

    }
}