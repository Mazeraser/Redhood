using Assets.Codebase.Infrastructure;
using Assets.Codebase.Infrastructure.InputService;
using Assets.Codebase.Mechanics.MoveSystem;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.Mechanics.ControllSystem
{
    [RequireComponent(typeof(Jump))]
    [RequireComponent(typeof(Dash))]
    [RequireComponent(typeof(Walk))]
    public class Player : MonoBehaviour,IControllable
    {
        private IInput _input;

        private Character _character;

        [SerializeField]
        private float _jumpTime;
        private float timer;

        private bool _jumped;

        private bool _isTurnedOnRight;

        [Inject]
        private void Construct(IInput input)
        {
            _input = input;
        }

        private void Awake()
        {
            _input.JumpPerformed += Jump;
            _input.DashPerformed += Dash;
        }

        private void Start()
        {
            _character = GetComponent<Character>();
        }

        private void FixedUpdate()
        {
            ControllMove(_input.Velocity);

            if (_input.JumpValue != 0f && !_jumped)
            {
                timer += Time.fixedDeltaTime;
                Jump(_input.Velocity);
            }
            else if (!GetComponent<Jump>().IsGrounded && _input.JumpValue == 0)
            {
                _jumped = true;
            }
            else if(GetComponent<Jump>().IsGrounded)
            {
                timer = 0;
                _jumped = false;
            }
        }

        public void ControllMove(Vector2 direction)
        {
            _character.Move(direction, GetComponent<Walk>());

            if (direction.x > 0)
                _isTurnedOnRight = true;
            else if(direction.x < 0)
                _isTurnedOnRight = false;
        }
        private void Jump(Vector2 direction)
        {
            if (timer < _jumpTime)
            {
                _character.Move(direction, GetComponent<Jump>());
            }
        }
        private void Dash()
        {
            _character.Move(new Vector2(_isTurnedOnRight?1:-1,0), GetComponent<Dash>());
        }
    }
}