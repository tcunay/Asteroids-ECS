using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;
using AteroidsECS.Factories;
using AteroidsECS.ScriptableObjects;
using AteroidsECS.Systems.Player;

namespace AteroidsECS.MonoBehaviours
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        
        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Init()
        {
            _world = new EcsWorld();

            var playerPrefab = new SpawnPrefab<Rigidbody2D>(_playerData.Prefab, _playerSpawnPoint.transform.position,
                _playerSpawnPoint.transform.rotation);

            _initSystems = new EcsSystems(_world).Add(new PlayerInitSystem()).Inject(_playerData)
                .Inject(playerPrefab);
            
            _updateSystems = new EcsSystems(_world).Add(new PlayerInputSystem()).Add(new PlayerShootSystem())
                .OneFrame<FirstWeaponEvent>().OneFrame<SecondWeaponEvent>();
            _fixedUpdateSystems = new EcsSystems(_world).Add(new PlayerMoveSystem<MoveComponent, MoveInputComponent>());
            
            _initSystems.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();

#if  UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems).name = nameof(_initSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems).name = nameof(_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems).name = nameof(_fixedUpdateSystems);
#endif
        }

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            _initSystems?.Destroy();
            _updateSystems?.Destroy();
            _fixedUpdateSystems?.Destroy();
            _world?.Destroy();
        }
    }
}
