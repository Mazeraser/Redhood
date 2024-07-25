using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Mechanics.MoveSystem
{
    public class Fly : MovableParent, IMovable
    {
        [SerializeField]
        private float _flySpeed;
        public float Speed
        {
            get { return _flySpeed; }
        }

        public void Turn(Vector2 direction)
        {
            Move(direction, _flySpeed);
        }
    }
}