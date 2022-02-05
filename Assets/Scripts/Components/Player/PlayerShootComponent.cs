using AteroidsECS.Events.Player.Shoot;
using UnityEngine;

namespace AteroidsECS.Components.Player
{
    public struct PlayerShootComponent
    {
        public void Init(string buletWeapon, string laserWeapon)
        {
            BuletWeapon = buletWeapon;
            LaserWeapon = laserWeapon;
        }

        public string BuletWeapon { get; private set; }
        public string LaserWeapon { get; private set; }

        public void Shoot(IShootEvent shootEvent)
        {
            switch (shootEvent)
            {
                case FirstWeaponShootEvent _:
                    Shoot(BuletWeapon);
                    break;
                case SecondWeaponShootEvent _:
                    Shoot(LaserWeapon);
                    break;
            }
        }

        private void Shoot(string weaponName)
        {
            Debug.Log("Shoot " + weaponName);
        }
    }
}