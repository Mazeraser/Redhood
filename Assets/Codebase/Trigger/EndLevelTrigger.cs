using System;
using UnityEngine;

namespace Assets.Codebase.Trigger
{
    [RequireComponent(typeof(Collider2D))]
    public class EndLevelTrigger : MonoBehaviour, ITrigger
    {
        public static event Action CompleteLevelEvent;

        public void PlayerEntered()
        {
            CompleteLevelEvent?.Invoke();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
                PlayerEntered();
        }
    }
}
    
