using UnityEngine;

namespace AteroidsECS.MonoBehaviours
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererMonoEntity : MonoEntity
    {
        public LineRenderer LineRenderer { get; private set; }
        
        public override void Init()
        {
            base.Init();
            LineRenderer = GetComponent<LineRenderer>();
        }
    }
}