using UnityEngine;

namespace AteroidsECS.Components.Abstract
{
    public interface IMoveComponent
    {
        void Move(float direction);
        void Rotate(float tourque);
    }
}