namespace AteroidsECS.Components.Abstract
{
    public interface IDirection
    {
        float MoveDirection { get; }
        float RotateDirection { get; }
    }
}