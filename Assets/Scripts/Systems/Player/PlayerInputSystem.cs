using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<InputComponent, PlayerComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var playerInput = ref _filter.Get1(i);
                
                playerInput.SetMoveDirection(Input.GetAxis("Vertical"));
                playerInput.SetRotateDirection(Input.GetAxis("Horizontal"));
            }
        }
    }
}