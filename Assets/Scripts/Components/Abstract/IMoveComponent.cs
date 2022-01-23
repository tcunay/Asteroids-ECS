using UnityEngine;

namespace AteroidsECS.Components.Abstract
{
    public interface IMoveComponent : IMoveProperties
    {
        void Move(float direction);
        void Rotate(float tourque);
    }
}