using System;
using AteroidsECS.Factories;
using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.ScriptableObjects;
using AteroidsECS.Systems;
using AteroidsECS.Systems.Player;
using AteroidsECS.Systems.Weapons;

namespace AteroidsECS.MonoBehaviours
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] private DefaultWeaponData _bulletData;
        [SerializeField] private LaserWeaponData _laserData;

        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        private PrefabFactory _factory;
        
        private void Awake() => Init();

        private void Update() => _updateSystems?.Run();

        private void FixedUpdate() => _fixedUpdateSystems?.Run();

        private void OnDestroy()
        {
            _initSystems?.Destroy();
            _updateSystems?.Destroy();
            _fixedUpdateSystems?.Destroy();
            _world?.Destroy();
        }
        
        private void Init()
        {
            _world = new EcsWorld();
            _factory = new PrefabFactory();

            IEntitySystems shootSystems = new WeaponsSystems(_world, _factory);
            IEntitySystems playerSystems = new PlayerSystems(_world, _playerData, _playerSpawnPoint, _factory, _bulletData, _laserData);

            InitSystems(playerSystems, shootSystems);
        }

        private void InitSystems(params IEntitySystems[] systems)
        {
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            foreach (var system in systems)
            {
                if (system.InitSystems != null)
                    _initSystems.Add(system.InitSystems);
                
                if (system.UpdateSystems != null)
                    _updateSystems.Add(system.UpdateSystems);
                
                if (system.FixedUpdateSystems != null)
                    _fixedUpdateSystems.Add(system.FixedUpdateSystems);
            }

            _initSystems.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems).name = nameof(_initSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems).name = nameof(_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems).name =
                nameof(_fixedUpdateSystems);
#endif
        }
    }
}