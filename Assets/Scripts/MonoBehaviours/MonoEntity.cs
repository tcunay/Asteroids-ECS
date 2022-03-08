using UnityEngine;

namespace AteroidsECS.MonoBehaviours
{
    public class MonoEntity : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}