using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;
using AteroidsECS.Factories;
using AteroidsECS.MonoBehaviours;
using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private PlayerData _data;
        private PlayerSpawnPoint _point;
        
        public void Init()
        {
            var playerEntity = _world.NewEntity();
            
            Rigidbody2D player = PlayerFactory.Create(_data.Prefab, _point.transform);

            playerEntity.Get<PlayerComponent>().Init(player.gameObject);
            playerEntity.Get<InputComponent>();
            playerEntity.Get<MoveComponent>().Init(player, _data.MoveSpeed, _data.RotateSpeed);
        }
    }
}