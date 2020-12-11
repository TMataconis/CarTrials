using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarChaseBehavior : EnemyCarBaseFSM
{
    public override void OnStateEnter(EnemyCar enemyCar)
    {
        // set enemyAgent speed
        enemyCar.enemyAgent.speed = 100f;
    }

    public override void OnStateExit(EnemyCar enemyCar)
    {
        
    }

    public override void OnStateUpdate(EnemyCar enemyCar)
    {
        // chase ball
        if (enemyCar.enemyAgent.enabled)
        {
            enemyCar.MoveToPointInGameWorld(enemyCar.ball.transform.position);
        }

        if (!enemyCar.isBallWithinRange())
        {
            // exit chase state
            OnStateExit(enemyCar);

            // move to patrol state
            enemyCar.MakeTransitionToNextFSMState(enemyCar.patrolBehavior);
        }
    }
}
