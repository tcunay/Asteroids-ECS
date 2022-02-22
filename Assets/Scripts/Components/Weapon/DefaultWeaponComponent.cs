using Leopotam.Ecs;

namespace AteroidsECS.Components.Weapon
{
    public struct DefaultWeaponComponent : IWeaponComponent
    {
        public DefaultWeaponComponent(EcsWorld world)
        {
            World = world;
        }

        public EcsWorld World { get;}

        public void Shoot()
        {
            var bullet = World.NewEntity();
            bullet.Get<DefaultBulletComponent>();
            bullet.Destroy();
        }
    }
}