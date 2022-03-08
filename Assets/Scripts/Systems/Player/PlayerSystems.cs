using AteroidsECS.Events.Move;
using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerSystems : IEntitySystems
    {
        public PlayerSystems(EcsWorld world, PlayerData playerData, PlayerSpawnPoint playerSpawnPoint, PrefabFactory factory, DefaultWeaponData defaultWeaponData)
        {
            var playerPrefab = new SpawnPrefab<RigidbodyEntity>(playerData.Prefab, playerSpawnPoint.transform.position,
                playerSpawnPoint.transform.rotation);

            InitSystems = new EcsSystems(world).Add(new PlayerInitSystem()).Inject(playerData).Inject(playerPrefab).Inject(factory).Inject(defaultWeaponData);
            UpdateSystems = new EcsSystems(world).Add(new PlayerInputSystem());
            FixedUpdateSystems = new EcsSystems(world).Add(new PlayerMoveSystem())
                .OneFrame<MoveEvent>();
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }
}