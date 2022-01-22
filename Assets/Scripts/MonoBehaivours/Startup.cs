using UnityEngine;
using Leopotam.Ecs;

public class Startup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _gameSystem;
    private EcsSystems _initSystems;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems;

    private void Init()
    {
        _world = new EcsWorld();
        _initSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _fixedUpdateSystems = new EcsSystems(_world);

        _gameSystem = new EcsSystems(_world).Add(_initSystems).Add(_updateSystems).Add(_fixedUpdateSystems);
        _gameSystem.Init();

#if  UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_gameSystem).name = nameof(_gameSystem);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems).name = nameof(_initSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems).name = nameof(_updateSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_gameSystem).name = nameof(_fixedUpdateSystems);
#endif
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        _gameSystem.Run();
    }

    private void FixedUpdate()
    {
        _gameSystem.Run();
    }

    private void OnDestroy()
    {
        _gameSystem.Destroy();
        _world.Destroy();
    }
}
