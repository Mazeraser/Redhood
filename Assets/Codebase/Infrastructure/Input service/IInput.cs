using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.InputService
{
    public interface IInput
    {
        Vector2 Velocity { get; }
        void IsJump();
        float JumpValue { get; }
        void IsDash();

        public event Action<Vector2> JumpPerformed;
        public event Action DashPerformed;

        void Activate();
        void Deactivate();
    }
}
    
