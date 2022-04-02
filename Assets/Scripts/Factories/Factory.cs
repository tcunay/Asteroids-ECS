using AteroidsECS.MonoBehaviours;
using AteroidsECS.MonoBehaviours.MonoEntities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AteroidsECS.Factories
{
    public class PrefabFactory
    {
        public T Create<T>(SpawnPrefab<T> spawnData) where T : MonoEntity
        {
            var monoEntity = Object.Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation);
            monoEntity.Init();
            return monoEntity;
        }

        public void Destroy(MonoEntity monoEntity ,float destroyTime = 0)
        {
            monoEntity.Destroy(destroyTime);
        }
    }
}