using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : EnemyBaseState
{
    public EnemyDamagedState(EnemyStateMachine currentContext, string animBoolName) : base(currentContext, animBoolName)
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
        if (Enemy.gameObject.GetComponent<ObstacleShake>() != null)
        {
            Enemy.gameObject.GetComponent<ObstacleShake>().enabled = true;
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        DoChecks();
        base.LogicUpdate();
        if (Time.time - startTime > 0.5)
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
        Enemy.AnimationController.SetAnim("Knockback");
    }
}
