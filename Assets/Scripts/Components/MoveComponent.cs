﻿using System;
using UnityEngine;
using AteroidsECS.Components.Abstract;

namespace AteroidsECS.Components
{
    public struct MoveComponent : IMoveComponent
    {
        public Rigidbody2D Rigidbody { get; private set; }
        public float Speed { get; private set; }
        public float RotateSpeed { get; private set; }

        public void Init(Rigidbody2D rigidbody, float speed, float rotateSpeed)
        {
            if (rigidbody == null || speed < 0 || rotateSpeed < 0)
                throw new InvalidOperationException();

            Rigidbody = rigidbody;
            Speed = speed;
            RotateSpeed = rotateSpeed;
        }

        public void Move(float direction) => Rigidbody.AddForce(Rigidbody.transform.up * direction * Speed, ForceMode2D.Force);

        public void Rotate(float tourque) => Rigidbody.AddTorque(tourque * RotateSpeed, ForceMode2D.Force);
    }
}