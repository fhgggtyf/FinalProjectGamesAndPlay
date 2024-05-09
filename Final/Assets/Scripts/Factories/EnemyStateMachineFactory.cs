using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyStateMachineFactory", menuName = "State Machine Factory/Enemy")]
public class EnemyStateMachineFactory : StateMachineFactory<EnemyStateMachine, Enemy, EnemyData, Core>
{
    public override EnemyStateMachine CreateStateMachine(Enemy Enemy, EnemyData data, Core core)
    {
        return new EnemyStateMachine(Enemy, data, core);
    }
}
