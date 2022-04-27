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
        private readonly WeaponData _weaponData;
        private readonly SpawnPrefab<RigidbodyEntity> _spawnData;

        public void Init()
        {
            var playerEntity = _world.NewEntity();

            RigidbodyEntity player = _prefabFactory.Create(_spawnData);
            
            InitWeapons(player, out IWeaponComponent bulletWeapon, out IWeaponComponent laserWeapon);
            
            playerEntity
                .Replace(new PlayerComponent(player.gameObject))
                .Replace(new MoveInputComponent())
                .Replace(new MoveComponent(player.Rigidbody, _data))
                .Replace(new PlayerShootComponent(bulletWeapon, laserWeapon));
        }

        private void InitWeapons( RigidbodyEntity player, out IWeaponComponent bulletWeapon, out IWeaponComponent laserWeapon)
        {
            bulletWeapon = new DefaultWeaponComponent(_world, _prefabFactory, _weaponData,
                player.Transform, player.Transform.up);
            
            laserWeapon = new DefaultWeaponComponent(_world, _prefabFactory, _weaponData,
                player.Transform, player.Transform.up);
        }
    }
}