namespace AteroidsECS.Events.Move
{
    public struct MoveEvent : IMoveEvent
    {
        public float MoveValue { get; private set; }
        public float RotateValue { get; private set; }
        
        public void Set(float moveDirection, float rotateDirection)
        {
            MoveValue = moveDirection;
            RotateValue = rotateDirection;
        }
    }
}