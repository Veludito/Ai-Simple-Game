using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        if (neighbors.Count == 0)
            return agent.transform.up;

        Vector2 avoidanceMove = Vector2.zero;
        int inAvoidRadius = 0;

        foreach (Transform item in neighbors)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
                inAvoidRadius++;
            }
        }

        if (inAvoidRadius > 0)
            avoidanceMove /= inAvoidRadius;

        return avoidanceMove;
    }
}
