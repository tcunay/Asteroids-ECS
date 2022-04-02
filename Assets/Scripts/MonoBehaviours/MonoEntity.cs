using UnityEngine;

namespace AteroidsECS.MonoBehaviours
{
    public class MonoEntity : MonoBehaviour
    {
        public void Destroy(float destroyTime = 0)
        {
            Destroy(gameObject, destroyTime);
        }
    }
}