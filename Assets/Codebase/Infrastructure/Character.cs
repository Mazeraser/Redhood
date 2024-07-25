using Assets.Codebase.Mechanics.AnimationSystem;
using Assets.Codebase.Mechanics.ControllSystem;
using Assets.Codebase.Mechanics.MoveSystem;
using UnityEngine;

namespace Assets.Codebase.Infrastructure
{
    [RequireComponent(typeof(CharacterAnimator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IControllable))]
    [RequireComponent(typeof(IMovable))]
    public class Character : MonoBehaviour
    {
        private CharacterAnimator _animator;
        private Rigidbody2D _rb;

        private void Start()
        {
            _animator = GetComponent<CharacterAnimator>();
            _rb = GetComponent<Rigidbody2D>();

            foreach (var movableComponent in GetComponents<MovableParent>())
                movableComponent.MoveDelegate = delegate { _animator.LastMoveName = movableComponent.GetType().Name; };
        }
        private void Update()
        {
            _animator.SetPhysicInteraction(_rb.velocity);
        }

        public void Move(Vector2 direction, IMovable movable)
        {
            movable.Turn(direction);
        }
        public void Move(Vector2 direction)
        {
            GetComponent<IMovable>().Turn(direction);
        }
    }
}