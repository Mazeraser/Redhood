using Assets.Codebase.Mechanics.MoveSystem;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Codebase.Infrastructure;

namespace Assets.Codebase.Mechanics.LifeSystem
{
    [RequireComponent(typeof(Character))]
    public class PlayerLife : MonoBehaviour, ILife
    {
        public static event Action PlayerIsDeathEvent;
        public void Die()
        {
            GetComponent<Character>().enabled = false;
            PlayerIsDeathEvent.Invoke();
        }
    }
}