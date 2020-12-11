using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Follow")]
public class CenterBehavior : FlockBehavior
{
    [SerializeField] float radius;
    [Range(0.1f, 0.9f)]
    [SerializeField] float percentage;
    [SerializeField] Vector2 target;
    public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        Vector2 pointToGo = target - (Vector2)agent.transform.position;
        float t = pointToGo.magnitude / radius;

        if (t < percentage)
        {
            return Vector2.zero;
        }

        return pointToGo * t * t;
    }
}
