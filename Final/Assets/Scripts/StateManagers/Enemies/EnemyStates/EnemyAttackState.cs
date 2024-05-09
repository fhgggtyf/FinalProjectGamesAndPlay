using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine currentContext, string animBoolName) : base(currentContext, animBoolName)
    {

    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void EnterState()
    {
        base.EnterState();
        CheckAnim();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        DoChecks();
        base.LogicUpdate();

        if (Enemy.AnimationController.GetCurrentAnim() != "Attack" || (Enemy.AnimationController.GetCurrentAnim() == "Attack" && Enemy.AnimationController.IsAnimFinished()))
        {
            _ctx.SwitchState(this, _ctx.Factory.Idle());
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        CheckAnim();
    }

    void CheckAnim()
    {
        Enemy.AnimationController.SetAnim("Attack");
    }
}
