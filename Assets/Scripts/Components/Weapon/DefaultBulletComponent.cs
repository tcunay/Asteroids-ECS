using System;
using AteroidsECS.Factories;
using AteroidsECS.ScriptableObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AteroidsECS.Components.Weapon
{
    public struct DefaultBulletComponent : IBullet
    {
        private Transform _bullet;

        public void Init(DefaultWeaponData defaultWeaponData, PrefabFactory factory, Transform spawnPoint,
            Vector2 direction)
        {
            if (defaultWeaponData == null)
            {
                Debug.LogError(new ArgumentNullException());
                return;
            }

            var spawnData = new SpawnPrefab<Transform>(defaultWeaponData.DefaultBulletPrefab.transform,
                spawnPoint.position, spawnPoint.rotation);
            
            _bullet = factory.Create(spawnData);
            factory.Destroy(_bullet, defaultWeaponData.Lifetime);

            Direction = direction;
            Damage = defaultWeaponData.Damage;
            Speed = defaultWeaponData.Speed;
            Lifetime = defaultWeaponData.Damage;
        }

        public int Damage { get; private set; }
        public float Speed { get; private set; }
        public float Lifetime { get; private set; }

        private Vector2 Direction { get; set; }

        public void Run()
        {
            if (_bullet == null)
            {
                Debug.LogError(new ArgumentNullException("bullet is NULL"));
                return;
            }

            _bullet.Translate(Direction * Speed * Time.deltaTime);
        }
    }
}