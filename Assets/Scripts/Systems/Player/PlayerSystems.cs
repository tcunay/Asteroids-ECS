using AteroidsECS.Events.Move;
using AteroidsECS.Events.Shoot;
using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;
using AteroidsECS.Systems.Weapons;

namespace AteroidsECS.Systems.Player
{
    public class PlayerSystems : IEntitySystems
    {
        public PlayerSystems(EcsWorld world, PlayerData playerData, PlayerSpawnPoint playerSpawnPoint
            , PrefabFactory factory, DefaultWeaponData defaultWeaponData, LaserWeaponData laserWeaponData)
        {
            var playerPrefab = new SpawnPrefab<RigidbodyEntity>(playerData.Prefab, playerSpawnPoint.transform.position,
                playerSpawnPoint.transform.rotation);

            InitSystems = new EcsSystems(world).Add(new PlayerInitSystem()).Inject(playerData)
                .Inject(playerPrefab).Inject(factory).Inject(defaultWeaponData).Inject(laserWeaponData);
            UpdateSystems = new EcsSystems(world).Add(new PlayerInputSystem()).Add(new PlayerWeaponShootEventSystem())
                .OneFrame<BulletWeaponShootEvent>().OneFrame<LaserWeaponShootEvent>();
            FixedUpdateSystems = new EcsSystems(world).Add(new PlayerMoveSystem())
                .OneFrame<MoveEvent>();
        }

        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }
    
    
    
}