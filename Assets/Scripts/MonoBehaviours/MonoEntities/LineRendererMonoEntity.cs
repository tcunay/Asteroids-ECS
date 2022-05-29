using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.MonoBehaviours.MonoEntities
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererMonoEntity : MonoEntity
    {
        public LineRenderer LineRenderer { get; private set; }
        
        public override void Init(EcsEntity entity)
        {
            base.Init(entity);
            LineRenderer = GetComponent<LineRenderer>();
        }
    }
}