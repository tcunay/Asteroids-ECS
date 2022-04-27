using System;
using UnityEngine;
using AteroidsECS.Components.Abstract;

namespace AteroidsECS.Components
{
    public struct MoveComponent : IMoveComponent
    {
        public MoveComponent(Rigidbody2D rigidbody, IMoveProperties properties)
        {
            if (rigidbody == null || properties.MoveValue < 0 || properties.RotateValue < 0)
                throw new InvalidOperationException();

            Rigidbody = rigidbody;
            MoveValue = properties.MoveValue;
            RotateValue = properties.RotateValue;
        }

        public float MoveValue { get; }
        public float RotateValue { get; }

        private Rigidbody2D Rigidbody { get; }

        public void Move(float direction) => Rigidbody.AddForce(Rigidbody.transform.up * direction * MoveValue, ForceMode2D.Force);

        public void Rotate(float tourque) => Rigidbody.AddTorque(tourque * RotateValue, ForceMode2D.Force);
    }
}