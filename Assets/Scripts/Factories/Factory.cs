using AteroidsECS.MonoBehaviours;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AteroidsECS.Factories
{
    public class PrefabFactory
    {
        public T Create<T>(SpawnPrefab<T> spawnData) where T : Object
        {
            return Object.Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation);
        }

        public void Destroy(MonoEntity monoEntity ,float destroyTime = 0)
        {
            monoEntity.Destroy(destroyTime);
        }
    }
}