namespace AteroidsECS.ScriptableObjects
{
    public interface IBulletBase
    {
        int Damage { get; }
        float Speed { get; }
        float MaxLifetime { get; }
    }
}