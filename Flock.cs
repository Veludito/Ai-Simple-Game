using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] int amount = 100;
    [SerializeField] FlockAgent prefab;
    [SerializeField] FlockBehavior flockBehavior;
    [SerializeField] AgentType agentColor;
    [SerializeField] LayerMask enemyLayer;
    List<FlockAgent> agents = new List<FlockAgent>();

    [Range(0.1f, 2f)]
    [SerializeField] float agentDensity = 0.8f;
    [Range(1f, 100f)]
    [SerializeField] float driveFactor = 10f;
    [Range(1f, 100f)]
    [SerializeField] float maxSpeed = 5f;
    [Range(1f, 10f)]
    [SerializeField] float neighbornRadius = 1.5f;
    [Range(0f, 1f)]
    [SerializeField] float avoidanceRadiusMultiplayer = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighbornRadius * neighbornRadius;
        squareAvoidanceRadius = avoidanceRadiusMultiplayer * avoidanceRadiusMultiplayer * squareNeighborRadius;

        Vector2 offset = transform.position;

        for (int i = 0; i < amount; i++)
        {
            FlockAgent agent = Instantiate(
                prefab,
                (Random.insideUnitCircle * amount * agentDensity) + offset,
                Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))),
                transform
                );

            agent.name = "Agent" + i;
            agent.tag = agentColor.ToString();
            agent.SetColor(agentColor);
            agents.Add(agent);
        }
    }

    private void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            if (agent != null)
            {
                List<Transform> neighbors = GetNeighbors(agent);
                Vector2 move = flockBehavior.CalculateMovement(agent, neighbors, this);
                move *= driveFactor;

                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }

                agent.Move(move);
            }
        }
    }

    List<Transform> GetNeighbors(FlockAgent agent)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbornRadius, enemyLayer);

        List<Transform> neighbors = new List<Transform>();

        foreach (Collider2D collider in colliders)
        {
            if (collider != agent.AgenteCollider && collider.tag == agentColor.ToString())
            {
                neighbors.Add(collider.transform);
            }
        }

        return neighbors;
    }
}
