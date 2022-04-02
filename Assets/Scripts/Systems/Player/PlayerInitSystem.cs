﻿using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly PlayerData _data;
        private readonly PrefabFactory _prefabFactory;
        private readonly SpawnPrefab<RigidbodyEntity> _spawnData;
        private readonly WeaponData _weaponData;

        public void Init()
        {
            var playerEntity = _world.NewEntity();

            RigidbodyEntity player = _prefabFactory.Create(_spawnData);
            
            IWeaponComponent bulletWeapon = new DefaultBulletWeaponComponent(_world, _prefabFactory, _weaponData, 
                player.Transform, player.Transform.up);
            IWeaponComponent laserWeapon = new DefaultBulletWeaponComponent(_world, _prefabFactory, _weaponData,
                player.Transform, player.Transform.up);

            playerEntity.Get<PlayerComponent>().Init(player.gameObject);
            playerEntity.Get<MoveInputComponent>();
            playerEntity.Get<MoveComponent>().Init(player.Rigidbody, _data);
            playerEntity.Get<PlayerShootComponent>().Init(bulletWeapon, laserWeapon, player.transform);
        }
    }
}