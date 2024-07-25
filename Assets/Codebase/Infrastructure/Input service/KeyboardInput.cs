using Codebase.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Zenject;

namespace Assets.Codebase.Infrastructure.InputService
{
    public class KeyboardInput : IInput, IInitializable, IDisposable
    {
        public event Action<Vector2> JumpPerformed;
        public event Action DashPerformed;

        private Main inputActions;

        public KeyboardInput()
        {
            inputActions = new Main();
        }

        public void Initialize()
        {
            Activate();
            inputActions.Move.Jump.performed += context => IsJump();
            inputActions.Move.Dash.performed += context => IsDash();
        }
        public void Dispose()
        {
            Deactivate();
        }

        public void Activate()
        {
            inputActions.Enable();
        }
        public void Deactivate()
        {
            inputActions.Disable();
        }

        public Vector2 Velocity 
        { 
            get { return inputActions.Move.Move.ReadValue<Vector2>(); } 
        }

        public void IsJump() 
        {
            JumpPerformed?.Invoke(Velocity);
        }
        public float JumpValue
        {
            get { return inputActions.Move.Move.ReadValue<Vector2>().y; }
        }
        public void IsDash() 
        {
            DashPerformed?.Invoke();
        }
    }
}
    
