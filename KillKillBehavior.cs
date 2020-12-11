using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Kill Kill")]
public class KillKillBehavior : FlockBehavior
{
    [SerializeField] float strengh;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] int radius = 4;
    public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        Collider2D player = Physics2D.OverlapCircle(agent.transform.position, radius, playerLayer);

        if (player == null)
            return Vector2.zero;

        Vector2 dir = player.transform.position - agent.transform.position;
        return dir * strengh;
    }
}
