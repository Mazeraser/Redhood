using UnityEngine;

namespace Assets.Codebase.Mechanics.MoveSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class MovableParent : MonoBehaviour
    {
        private Collider2D _collider;
        private Rigidbody2D _rb;

        public delegate void MovePerformed();
        public MovePerformed MoveDelegate;

        private enum Move_type
        {
            first_physical=0,
            second_physical=1,
            first_nonphysical=2,
        }
        [SerializeField]
        private Move_type _type;

        public virtual void Start()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
        }

        protected void Move(Vector2 direction, float speed)
        {
            //Physical realization, gives momentum to the body and it "rolls"
            //IMPORTANT: CapsuleCollider gives the minimal braking due to frictional force

            Vector2 movement = new Vector2(direction.x, direction.y);

            switch ((int)_type)
            {
                case 0:
                    _rb.AddForce(movement * speed);
                    break;
                case 1:
                    _rb.AddForce(movement * speed, ForceMode2D.Impulse);
                    break;
                    /*Features:
                    -The character stops for a while.

                    -The running jump is stronger.

                    -The character moves faster in a jump
                    */
                case 2:
                    //Non-physical realization, moves body through coordinate system, uses teleportation
                    // so that the speed would be stable in any case
                    // and given that we call from FixedUpdate we multiply by fixedDeltaTime.
                    transform.Translate(movement * speed * Time.fixedDeltaTime);
                    break;
            }
            MoveDelegate?.Invoke();
        }
    }
}