using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private PlayerData _data;
        private PrefabFactory _prefabFactory;
        private SpawnPrefab<Rigidbody2D> _spawnData;

        public void Init()
        {
            IWeaponComponent bulletWeapon = new DefaultWeaponComponent();
            IWeaponComponent laserWeapon = new DefaultWeaponComponent();
            var playerEntity = _world.NewEntity();

            Rigidbody2D player = _prefabFactory.Create(_spawnData);

            playerEntity.Get<PlayerComponent>().Init(player.gameObject);
            playerEntity.Get<MoveInputComponent>();
            playerEntity.Get<MoveComponent>().Init(player, _data);
            playerEntity.Get<PlayerShootComponent>().Init(bulletWeapon, laserWeapon, player.transform);
        }
    }
}