using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Mechanics.ControllSystem
{
    public interface IControllable
    {
        void ControllMove(Vector2 direction);
    }
}