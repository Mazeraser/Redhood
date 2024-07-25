using UnityEngine;

namespace Assets.Codebase.Mechanics.MoveSystem
{
    public class Walk : MovableParent, IMovable
    {
        [SerializeField]
        private float _speed;
        public float Speed
        {
            get { return _speed; }
        }

        public void Turn(Vector2 direction)
        {
            Move(new Vector2(direction.x, 0), _speed);
        }
    }
}