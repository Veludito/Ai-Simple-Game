using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        if (neighbors.Count == 0)
            return agent.transform.up;

        Vector2 alignmentMove = Vector2.zero;

        foreach (Transform item in neighbors)
        {
            alignmentMove += (Vector2)item.transform.up;
        }

        alignmentMove /= neighbors.Count;

        return alignmentMove;
    }
}
