using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    [SerializeField] float[] weights;

    public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("Lenghts of the arrays do not match");
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 behaviorMove = behaviors[i].CalculateMovement(agent, neighbors, flock) * weights[i];

            if(behaviorMove != Vector2.zero)
            {
                if(behaviorMove.sqrMagnitude > weights[i] * weights[i])
                {
                    behaviorMove.Normalize();
                    behaviorMove *= weights[i];
                }
            }

            move += behaviorMove;
        }

        return move;
    }
}
