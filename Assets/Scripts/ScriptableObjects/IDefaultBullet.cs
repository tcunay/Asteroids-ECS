namespace AteroidsECS.ScriptableObjects
{
    public interface IDefaultBullet
    {
        int Damage { get; }
        float Speed { get; }
        float Lifetime { get; }
    }
}