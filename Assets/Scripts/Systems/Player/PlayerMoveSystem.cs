using UnityEngine;
using Leopotam.Ecs;
using AteroidsECS.Components.Abstract;
using AteroidsECS.Components.Player;

namespace AteroidsECS.Systems.Player
{
    public class PlayerMoveSystem<TMoveComponent, TInputComponent>
        : IEcsRunSystem where TMoveComponent : struct, IMoveComponent where TInputComponent : struct, IDirection
    {
        private EcsWorld _world;
        private EcsFilter<TMoveComponent, TInputComponent, PlayerComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveComponent = ref _filter.Get1(i);
                ref var directionComponent = ref _filter.Get2(i);

                moveComponent.Move(Mathf.Clamp01(directionComponent.MoveDirection));

                moveComponent.Rotate(-directionComponent.RotateDirection);
            }
        }
    }
}