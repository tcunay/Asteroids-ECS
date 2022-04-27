using Leopotam.Ecs;
using UnityEngine;

namespace AteroidsECS.Components.Player
{
    public struct PlayerComponent : IEcsIgnoreInFilter
    {
        public PlayerComponent(GameObject gameObject)
        {
            GameObject = gameObject;
        }
        
        public GameObject GameObject { get; }
    }
}