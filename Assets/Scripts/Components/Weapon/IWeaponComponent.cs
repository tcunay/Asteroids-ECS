using Leopotam.Ecs;

namespace AteroidsECS.Components.Weapon
{
    public interface IWeaponComponent
    {
        EcsWorld World { get; }
        
        void Shoot();
    }
}