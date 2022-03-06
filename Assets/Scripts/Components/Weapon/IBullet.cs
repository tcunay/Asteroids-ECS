using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Components.Weapon
{
    public interface IBullet : IDefaultBullet
    {
        void Run();
    }
}