using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Path2D
{
    public class PatrolmanWalker : WalkerAbstraction
    {
        public override void ChoosePosition()
        {
            if (currentWaypointIndex == -1)
            {
                currentWaypointIndex = 0;
            }
            else if (Vector3.Distance(transform.position, currentPath.waypoints[currentWaypointIndex].position) < changeDistance)
            {
                currentWaypointIndex = currentPath.waypoints[currentWaypointIndex].connectedWaypointsIndices[0];
                Debug.Log($"Position changed on {currentWaypointIndex}");
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Path"))
                currentPath = collision.GetComponent<Path>();
        }
    }
}
