using AteroidsECS.ScriptableObjects;

namespace AteroidsECS.Components.Weapon
{
    public interface IBullet : IBulletBase
    {
        void Run();
    }
}