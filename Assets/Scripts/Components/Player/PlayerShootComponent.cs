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

        public void Shoot(IEvent shootEvent)
        {
            switch (shootEvent)
            {
                case FirstWeaponEvent _:
                    Shoot(BuletWeapon);
                    break;
                case SecondWeaponEvent _:
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