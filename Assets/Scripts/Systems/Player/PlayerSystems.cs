using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerSystems
    {
        public PlayerSystems(EcsWorld world, PlayerData playerData, PlayerSpawnPoint playerSpawnPoint)
        {
            var playerPrefab = new SpawnPrefab<Rigidbody2D>(playerData.Prefab, playerSpawnPoint.transform.position,
                playerSpawnPoint.transform.rotation);

            InitSystems = new EcsSystems(world).Add(new PlayerInitSystem()).Inject(playerData)
                .Inject(playerPrefab);
            UpdateSystems = new EcsSystems(world).Add(new PlayerInputSystem()).Add(new PlayerShootSystem())
                .OneFrame<FirstWeaponEvent>().OneFrame<SecondWeaponEvent>();
            FixedUpdateSystems = new EcsSystems(world).Add(new PlayerMoveSystem<MoveComponent, MoveInputComponent>());
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }
}