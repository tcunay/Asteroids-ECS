using System;
using UnityEngine;
using AteroidsECS.Components.Abstract;

namespace AteroidsECS.Components
{
    public struct MoveComponent : IMoveComponent
    {
        public void Init(Rigidbody2D rigidbody, IMoveProperties properties)
        {
            if (rigidbody == null || properties.MoveSpeed < 0 || properties.RotateSpeed < 0)
                throw new InvalidOperationException();

            Rigidbody = rigidbody;
            MoveSpeed = properties.MoveSpeed;
            RotateSpeed = properties.RotateSpeed;
        }

        public float MoveSpeed { get; private set; }
        public float RotateSpeed { get; private set; }

        private Rigidbody2D Rigidbody { get; set; }

        public void Move(float direction) => Rigidbody.AddForce(Rigidbody.transform.up * direction * MoveSpeed, ForceMode2D.Force);

        public void Rotate(float tourque) => Rigidbody.AddTorque(tourque * RotateSpeed, ForceMode2D.Force);
    }
}