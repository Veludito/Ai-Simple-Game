using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterStates : MonoBehaviour//hunter state machine
{
    public State hunterState { get; private set; }
    int reactors;

    private void Start()
    {
        Reactor.OnReactorDestroyed.AddListener(Setreactors);
        reactors = GameObject.FindGameObjectsWithTag("Reactor").Length;
    }

    private void Update()
    {
        if (HunterLife.currentLife <= 5)
        {
            ChangeState(State.RunningAway);
        }
        else
        {
            if (reactors == 4)
            {
                ChangeState(State.Idle);
            }
            else if (reactors > 1)
            {
                ChangeState(State.Hunting);
            }
            else
            {
                ChangeState(State.HuntingAngry);
            }
        }
    }

    void Setreactors() => reactors--;

    public void ChangeState(State newState)
    {
        if (newState == hunterState)
            return;

        hunterState = newState;
        Debug.Log(hunterState);
    }
}
public enum State { Idle, Hunting, RunningAway, HuntingAngry }
