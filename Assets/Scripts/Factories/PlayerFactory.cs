using UnityEngine;
using Object = UnityEngine.Object;

namespace AteroidsECS.Factories
{
    public static class PlayerFactory
    {
        public static T Create<T>(SpawnPrefab<T> spawnData) where T : Object
        {
            return Object.Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation);
        }
    }
}