using Leopotam.Ecs;

namespace AteroidsECS.Systems
{
    public interface IEntitySystems
    {
        public IEcsInitSystem InitSystems { get; }
        public IEcsRunSystem UpdateSystems { get; }
        public IEcsRunSystem FixedUpdateSystems { get; }
    }
}