using System;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;
using UnityEngine;

namespace AteroidsECS.Components.Weapon
{
    public struct LaserBulletComponent : IBullet
    {
        private readonly LineRendererMonoEntity _bullet;
        
        public LaserBulletComponent(LineRendererMonoEntity bullet, PrefabFactory factory)
        {
            _bullet = bullet;
            Damage = 0;
            Speed = 0;
            MaxLifetime = 0;
        }


        public int Damage { get; }
        public float Speed { get; }
        public float MaxLifetime { get; }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
    
    public struct DefaultBulletComponent : IBullet
    {
        private readonly MonoEntity _bullet;
        private readonly PrefabFactory _factory;

        public DefaultBulletComponent(WeaponData weaponData, PrefabFactory factory, Transform spawnPoint,
            Vector2 direction)
        {
            if (weaponData == null || factory == null || spawnPoint == null)
            {
                Debug.LogError(new ArgumentNullException());
            }

            _factory = factory;
            var spawnData = new SpawnPrefab<MonoEntity>(weaponData.DefaultBulletPrefab,
                spawnPoint.position, spawnPoint.rotation);
            
            _bullet = _factory.Create(spawnData);
            
            Direction = direction;
            Damage = weaponData.Damage;
            Speed = weaponData.Speed;
            MaxLifetime = weaponData.MaxLifetime;
            CreateTime = Time.time;
            Died = null;
        }

        public event Action Died;

        public int Damage { get; private set; }
        public float Speed { get; private set; }
        public float MaxLifetime { get; private set; }
        public bool IsLifeTimeEnded => LifeTime > MaxLifetime;

        private Vector2 Direction { get; set; }
        private float CreateTime { get; set; }
        private float LifeTime => Time.time - CreateTime;

        public void Run()
        {
            if (_bullet == null)
            {
                Debug.LogError(new ArgumentNullException("bullet is NULL"));
                return;
            }

            _bullet.Transform.Translate(Direction * Speed * Time.deltaTime);
        }

        public void Destroy()
        {
            _factory.Destroy(_bullet);
            Died?.Invoke();
        }
    }
}