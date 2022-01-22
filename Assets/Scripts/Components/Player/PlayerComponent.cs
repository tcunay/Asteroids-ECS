using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.Components.Player
{
    public struct PlayerComponent : IEcsIgnoreInFilter
    {
        public GameObject GameObject { get; private set; }

        public void Init(GameObject gameObject)
        {
            GameObject = gameObject;
        }
        
    }
}