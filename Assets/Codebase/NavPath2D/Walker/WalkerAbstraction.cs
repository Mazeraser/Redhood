using Assets.Codebase.Mechanics.ControllSystem;
using Assets.Codebase.Mechanics.MoveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Path2D
{
    public abstract class WalkerAbstraction : MonoBehaviour
    {
        [SerializeField]
        protected float changeDistance = 1f;

        protected Path currentPath;
        protected int currentWaypointIndex = -1;
        public float speed = 2f;

        private void Update()
        {
            ChoosePosition();
            Walk();
        }
        public virtual void Walk()
        {
            Vector3 waypointPosition = currentPath.waypoints[currentWaypointIndex].position;
            GetComponent<IControllable>().ControllMove((waypointPosition - transform.position).normalized);
        }
        public virtual void ChoosePosition()
        {
            return;
        }
    }
}