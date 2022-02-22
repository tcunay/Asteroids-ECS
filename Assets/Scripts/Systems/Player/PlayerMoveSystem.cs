using Leopotam.Ecs;
using AteroidsECS.Components;
using AteroidsECS.Events.Player.Move;
using UnityEngine;

namespace AteroidsECS.Systems.Player
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent> _filter;
        private EcsFilter<MoveEvent> _moveEventFilter;

        public void Run()
        {
            foreach (var i in _moveEventFilter)
            {
                ref var moveEvent = ref _moveEventFilter.Get1(i);
                
                TryMove(moveEvent);
            }
        }

        private void TryMove(IMoveEvent moveEvent)
        {
            foreach (var i in _filter)
            {
                ref var moveComponent = ref _filter.Get1(i);
                moveComponent.Move(moveEvent.MoveValue * Time.fixedDeltaTime);
                moveComponent.Rotate(moveEvent.RotateValue * Time.fixedDeltaTime);
            }
        }
    }
}