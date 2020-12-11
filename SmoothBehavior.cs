using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Smooth")]
public class SmoothBehavior : FlockBehavior
{
    Vector2 currentVelocity;
    [Range(0.1f, 2f)]
    [SerializeField] float smoothness = 0.5f;
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
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, smoothness);

        return cohesionMove;
    }
}
