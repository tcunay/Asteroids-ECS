using System;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;
using UnityEngine;

namespace AteroidsECS.Components.Weapon
{
    public struct LaserBulletComponent : IBullet
    {
        private readonly LineRendererMonoEntity _bullet;
        
        public LaserBulletComponent(LineRendererMonoEntity bullet)
        {
            _bullet = bullet;
            Distance = 20;
            Damage = 0;
            Speed = 0;
            MaxLifetime = 0;
        }
        
        public int Damage { get; }
        public float Speed { get; }
        public float MaxLifetime { get; }
        public float Distance { get; }
        
        public void Run()
        {
            var position = _bullet.Transform.position;
            var distanceDirection = _bullet.Transform.up * Distance;

            CastRay(position, distanceDirection);
            RenderLine(position, position + distanceDirection);
        }
        
        private void CastRay(Vector3 startPosition, Vector3 endPosition)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(startPosition, endPosition);
            foreach (var hit in hits)
            {
                /*if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    Destroy(enemy.gameObject);
                }*/
            }

#if UNITY_EDITOR
            Debug.DrawRay(startPosition, endPosition);
#endif
        }

        private void RenderLine(Vector3 startPosition, Vector3 endPosition)
        {
            _bullet.LineRenderer.SetPosition(1, startPosition);
            _bullet.LineRenderer.SetPosition(0, endPosition);
        }
    }
    
    public struct DefaultBulletComponent : IBullet
    {
        private readonly MonoEntity _bullet;
        private readonly PrefabFactory _factory;
        
        public event Action Died;

        public DefaultBulletComponent(DefaultWeaponData defaultWeaponData, PrefabFactory factory, Transform spawnPoint,
            Vector2 direction)
        {
            if (defaultWeaponData == null || factory == null || spawnPoint == null)
            {
                throw new ArgumentNullException();
            }

            _factory = factory;
            var spawnData = new SpawnPrefab<MonoEntity>(defaultWeaponData.DefaultBulletPrefab,
                spawnPoint.position, spawnPoint.rotation);
            
            _bullet = _factory.Create(spawnData);
            
            Direction = direction;
            Damage = defaultWeaponData.Damage;
            Speed = defaultWeaponData.Speed;
            MaxLifetime = defaultWeaponData.MaxLifetime;
            CreateTime = Time.time;
            Died = null;
        }

        public int Damage { get; }
        public float Speed { get; }
        public float MaxLifetime { get; }
        public bool IsLifeTimeEnded => LifeTime > MaxLifetime;

        private Vector2 Direction { get; }
        private float CreateTime { get; }
        private float LifeTime => Time.time - CreateTime;

        public void Run()
        {
            if (_bullet == null)
                throw new ArgumentNullException("bullet is NULL");

            _bullet.Transform.Translate(Direction * Speed * Time.deltaTime);
        }

        public void Destroy()
        {
            _factory.Destroy(_bullet);
            Died?.Invoke();
        }
    }
}