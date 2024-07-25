using UnityEngine;

namespace Assets.Codebase.Mechanics.MoveSystem
{
    public interface IMovable
    {
        float Speed { get; }
        void Turn(Vector2 direction);
    }
}