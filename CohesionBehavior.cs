using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Cohesion")]
public class CohesionBehavior : FlockBehavior
{
    public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        if (neighbors.Count == 0)
            return Vector2.zero;

        Vector2 cohesionMove = Vector2.zero;

        foreach (Transform item in neighbors)
        {
            cohesionMove += (Vector2)item.position;
        }

        cohesionMove /= neighbors.Count;

        cohesionMove -= (Vector2)agent.transform.position;

        return cohesionMove;
    }
}
