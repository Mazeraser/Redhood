using UnityEngine;

namespace Assets.Codebase.Mechanics.AnimationSystem
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour
    {
        public enum CharacterState
        {
            idle=0,
            walk=1,
            jump=2,
            fall=3,
            dash=4,
        }
        private CharacterState state;
        public void SetState(int stateID) => state = (CharacterState)stateID;

        public string LastMoveName { get; set; }

        public void SetPhysicInteraction(Vector2 bodyVelocity)
        {
            if (bodyVelocity.magnitude == 0)
                SetState(LastMoveName.Contains("Walk") ? 1:0);
            else if (bodyVelocity.y > 0)
                SetState(2);
            else if (bodyVelocity.y < 0)
                SetState(3);
            else
                SetState(4);

            GetComponent<Animator>().SetInteger("state", (int)state);
        }
    }
}