using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory : StateFactory<EnemyStateMachine,EnemyBaseState>
{
    public EnemyStateFactory(EnemyStateMachine context) : base(context)
    {

    }

    public EnemyBaseState Idle()
    {
        return new EnemyIdleState(_context, "Idle");
    }

    public EnemyBaseState Damaged()
    {
        return new EnemyDamagedState(_context, "Damaged");
    }

    public EnemyBaseState Attack()
    {
        return new EnemyAttackState(_context, "Attack");
    }
}
