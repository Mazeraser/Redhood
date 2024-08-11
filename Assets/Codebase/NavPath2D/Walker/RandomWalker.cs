using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Path2D
{
    public class RandomWalker : WalkerAbstraction
    {
        public override void ChoosePosition()
        {
            if (currentPath.waypoints.Count == 0) return;
            if (currentWaypointIndex == -1 || 
                Vector3.Distance(transform.position, currentPath.waypoints[currentWaypointIndex].position) < changeDistance)
            {
                if (currentWaypointIndex == -1)
                {
                    currentWaypointIndex = Random.Range(0, currentPath.waypoints.Count);
                }
                else
                {
                    int nextWaypointIndex = currentPath.waypoints[currentWaypointIndex].GetRandomConnectedWaypointIndex();
                    if (nextWaypointIndex != -1)
                    {
                        currentWaypointIndex = nextWaypointIndex;
                    }
                    else
                    {
                        currentWaypointIndex = Random.Range(0, currentPath.waypoints.Count);
                    }
                }
            }
        }
    }
}