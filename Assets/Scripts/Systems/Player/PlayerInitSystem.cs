using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;
using AteroidsECS.Components.Weapon;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours.MonoEntities;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly PlayerData _data;
        private readonly PrefabFactory _prefabFactory;
        private readonly DefaultWeaponData _defaultWeaponData;
        private readonly LaserWeaponData _laserData;
        private readonly SpawnPrefab<RigidbodyEntity> _spawnData;

        public void Init()
        {
            var playerEntity = _world.NewEntity();

            RigidbodyEntity player = _prefabFactory.Create(_spawnData);
            
            var bulletWeapon = new DefaultWeaponComponent(_defaultWeaponData, _prefabFactory, player.Transform, player.Transform.up);
            var laserWeapon = new LaserWeaponComponent(_laserData, _prefabFactory, player.transform);
            
            playerEntity
                .Replace(new PlayerComponent(player.gameObject))
                .Replace(new MoveInputComponent())
                .Replace(new MoveComponent(player.Rigidbody, _data))
                .Replace(new PlayerShootComponent(bulletWeapon, laserWeapon));
        }
    }
}