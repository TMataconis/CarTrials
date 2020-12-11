using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCarBaseFSM
{
    // enter, update, exit
    public abstract void OnStateEnter(EnemyCar enemyCar);

    public abstract void OnStateUpdate(EnemyCar enemyCar);

    public abstract void OnStateExit(EnemyCar enemyCar);
}
// concrete classes -> patrol, chase
