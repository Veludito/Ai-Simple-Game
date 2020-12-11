using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] float velocity = 5, velocityAngry = 8;
    Transform player;
    HunterStates hs;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hs = GetComponent<HunterStates>();
    }

    private void Update()
    {
        if(hs.hunterState != State.Idle)
        {
            if (hs.hunterState == State.Hunting || hs.hunterState == State.HuntingAngry)
            {
                Move();
            }
            else if(hs.hunterState == State.RunningAway)
            {
                Move(false);
            }
        }
    }

    public void Move(bool goingFront = true)
    {
        float desiredVelocity = hs.hunterState == State.Hunting ? velocity : velocityAngry;
        desiredVelocity = goingFront ? desiredVelocity : -desiredVelocity;
        Vector2 movement = (player.position - transform.position).normalized;
        transform.up = movement;
        transform.position += (Vector3)movement * desiredVelocity * Time.deltaTime;
    }
}
