using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : Enemy
{
    public Vector3 pointOfInterest;

    // current state of FSM
    public EnemyCarBaseFSM currentState;

    // reference for all concrete classes
    public EnemyCarPatrolBehavior patrolBehavior = new EnemyCarPatrolBehavior();
    public EnemyCarChaseBehavior chaseBehavior = new EnemyCarChaseBehavior();


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        // store enemyCar starting position
        pointOfInterest = transform.position;

        // Start in patrol state
        MakeTransitionToNextFSMState(patrolBehavior);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate(this);
    }

    public void MakeTransitionToNextFSMState(EnemyCarBaseFSM stateToMove)
    {
        // store currentState
        currentState = stateToMove;

        // move to next state
        currentState.OnStateEnter(this);
    }

    // if Ball is within Patrol Radius, return true
    public bool isBallWithinRange()
    {

        if (GetSquareMagnitudeDistanceOfObject(ball.transform.position, transform.position) < GameConstants.ENEMY_FOV_DISTANCE)
        {
            return true;
        }
        else return false;
    }
}
