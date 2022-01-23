using AteroidsECS.Components.Abstract;

namespace AteroidsECS.Components
{
    public struct MoveInputComponent : IDirection
    {
        public float MoveDirection { get; private set; }
        public float RotateDirection { get; private set; }

        public void SetMoveDirection(float direction) => MoveDirection = direction;
        public void SetRotateDirection(float direction) => RotateDirection = direction;
    }
}