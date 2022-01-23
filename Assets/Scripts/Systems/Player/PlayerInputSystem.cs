using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Components.Player;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<MoveInputComponent, PlayerComponent> _filter;

        public void Run()
        {
            RunMoveInput();
            RunShootInput();
        }

        private void RunShootInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _world.NewEntity().Get<FirstWeaponEvent>();

            if (Input.GetKeyDown(KeyCode.LeftShift))
                _world.NewEntity().Get<SecondWeaponEvent>();
        }

        private void RunMoveInput()
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