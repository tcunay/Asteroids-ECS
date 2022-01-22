using UnityEngine;
using Object = UnityEngine.Object;

namespace AteroidsECS.Factories
{
    public static class PlayerFactory
    {
        public static T Create<T>(T prefab , Transform spawnPoint) where T : Object
        {
            return Object.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}