using AteroidsECS.Events.Move;
using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Events.Shoot;

namespace AteroidsECS.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;

        public void Run()
        {
            RunMoveInput();
            RunShootInput();
        }

        private void RunShootInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _world.NewEntity().Get<BulletWeaponShootEvent>();

            if (Input.GetKeyDown(KeyCode.LeftShift))
                _world.NewEntity().Get<LaserWeaponShootEvent>();
        }

        private void RunMoveInput()
        {
            _world.NewEntity().Get<MoveEvent>().
                Set(Input.GetAxis("Vertical"), -Input.GetAxis("Horizontal"));
        }
    }
}