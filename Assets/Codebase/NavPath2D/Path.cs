using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Path2D
{
    public class Path : MonoBehaviour
    {
        public List<Waypoint> waypoints = new List<Waypoint>();
    
        void OnDrawGizmos()
        {
            if (waypoints == null || waypoints.Count == 0) return;

            for (int i = 0; i < waypoints.Count; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(waypoints[i].position, 0.5f);
                foreach (var connectedIndex in waypoints[i].connectedWaypointsIndices)
                {
                    if (connectedIndex >= 0 && connectedIndex < waypoints.Count)
                    {
                        Gizmos.color = Color.green;
                        Gizmos.DrawLine(waypoints[i].position, waypoints[connectedIndex].position);
                    }
                }
            
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            foreach (Waypoint waypoint in waypoints)
            {
                Gizmos.DrawWireSphere(waypoint.position, 0.5f);
            }
        }
    }
}