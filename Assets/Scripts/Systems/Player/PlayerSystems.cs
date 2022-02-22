using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Events.Player.Move;
using AteroidsECS.Events.Player.Shoot;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerSystems : IEntitySystems
    {
        public PlayerSystems(EcsWorld world, PlayerData playerData, PlayerSpawnPoint playerSpawnPoint, PrefabFactory factory)
        {
            var playerPrefab = new SpawnPrefab<Rigidbody2D>(playerData.Prefab, playerSpawnPoint.transform.position,
                playerSpawnPoint.transform.rotation);

            InitSystems = new EcsSystems(world).Add(new PlayerInitSystem()).Inject(playerData).Inject(playerPrefab).Inject(factory);
            UpdateSystems = new EcsSystems(world).Add(new PlayerInputSystem()).Add(new PlayerShootSystem())
                .OneFrame<FirstWeaponShootEvent>().OneFrame<SecondWeaponShootEvent>();
            FixedUpdateSystems = new EcsSystems(world).Add(new PlayerMoveSystem())
                .OneFrame<MoveEvent>();
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }
}