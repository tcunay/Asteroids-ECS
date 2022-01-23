using UnityEngine;

namespace AteroidsECS.Factories
{
    public struct SpawnPrefab<T> where T : Object
    {
        public SpawnPrefab(T prefab, Vector2 position, Quaternion rotation)
        {
            Prefab = prefab;
            Position = position;
            Rotation = rotation;
        }

        public T Prefab { get; private set; }
        public Vector2 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
    }
}