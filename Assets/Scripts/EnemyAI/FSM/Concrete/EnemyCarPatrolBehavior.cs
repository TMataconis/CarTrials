using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarPatrolBehavior : EnemyCarBaseFSM
{
    private float _counter = 0;
    private float _patrolTime = 2;

    public override void OnStateEnter(EnemyCar enemyCar)
    {
        // set speed of enemyCar
        enemyCar.enemyAgent.speed = 20f;

        // choose new position and move towards
        Vector3 newPatrolPosition = enemyCar.GetRandomPositionWithinRadius(enemyCar.pointOfInterest, GameConstants.ENEMY_PATROL_RADIUS);
        enemyCar.MoveToPointInGameWorld(newPatrolPosition);
    }

    public override void OnStateExit(EnemyCar enemyCar)
    {
        
    }

    public override void OnStateUpdate(EnemyCar enemyCar)
    {
        // every few seconds pick a random point and move
        _counter += Time.deltaTime;
        if (_counter >= _patrolTime)
        {
            // pick new position and move
            Vector3 newPatrolPosition = enemyCar.GetRandomPositionWithinRadius(enemyCar.pointOfInterest, GameConstants.ENEMY_PATROL_RADIUS);
            enemyCar.MoveToPointInGameWorld(newPatrolPosition);

            _counter = 0;
        }

        // move to chase if ball is within fov radius
        if (enemyCar.isBallWithinRange())
        {
            // exit current state
            OnStateExit(enemyCar);

            // move to chase state
            enemyCar.MakeTransitionToNextFSMState(enemyCar.chaseBehavior);
        }
    }
}
