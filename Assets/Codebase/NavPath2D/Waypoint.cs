using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Path2D
{
    [System.Serializable]
    public class Waypoint
    {
        public Vector3 position;
        public List<int> connectedWaypointsIndices = new List<int>();
        public int GetRandomConnectedWaypointIndex()
        {
            if (connectedWaypointsIndices.Count == 0)
                return -1;
            int randomIndex = Random.Range(0, connectedWaypointsIndices.Count);
            return connectedWaypointsIndices[randomIndex];
        }
    }
}