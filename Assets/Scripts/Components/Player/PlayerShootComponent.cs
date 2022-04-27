using AteroidsECS.Components.Weapon;
using AteroidsECS.Events.Shoot;
using UnityEngine;

namespace AteroidsECS.Components.Player
{
    public struct PlayerShootComponent
    {
        public PlayerShootComponent(IWeaponComponent bulletWeapon, IWeaponComponent laserWeapon)
        {
            BuletWeapon = bulletWeapon;
            LaserWeapon = laserWeapon;
        }

        public IWeaponComponent BuletWeapon { get; }
        public IWeaponComponent LaserWeapon { get; }

    }
}