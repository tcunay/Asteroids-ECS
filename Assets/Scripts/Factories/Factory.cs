using UnityEngine;
using AteroidsECS.MonoBehaviours.MonoEntities;
using Leopotam.Ecs;
using Object = UnityEngine.Object;

namespace AteroidsECS.Factories
{
    public class PrefabFactory
    {
        public T Create<T>(SpawnPrefab<T> spawnData) where T : MonoEntity
        {
            var monoEntity = Object.Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation);
            return monoEntity;
        }

        public T Create<T>(T monoEntityPrefab, Transform parent) where T : MonoEntity
        {
            var monoEntity = Object.Instantiate(monoEntityPrefab, parent);
            return monoEntity;
        }

        public void Destroy(MonoEntity monoEntity ,float destroyTime = 0)
        {
            monoEntity.Destroy(destroyTime);
        }
    }
}