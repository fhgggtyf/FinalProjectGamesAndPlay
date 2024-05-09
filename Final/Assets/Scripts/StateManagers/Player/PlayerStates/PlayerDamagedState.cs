using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerBaseState
{
    public PlayerDamagedState(PlayerStateMachine currentContext, string animBoolName) : base(currentContext, animBoolName)
    {
        IsRootState = true;
        InitializeSubstate();
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

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void InitializeSubstate()
    {
    }

    public override void LogicUpdate()
    {
        DoChecks();
        base.LogicUpdate();
        if (Time.time - startTime > 0.5 )
        {
            if (isGrounded)
            {
                _ctx.SwitchState(this, _ctx.Factory.Grounded());
            }
            if (!isGrounded)
            {
                _ctx.SwitchState(this, _ctx.Factory.InAir());
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        CheckAnim();
    }

    void CheckAnim()
    {
        Player.AnimationController.SetAnim("Knockback");
    }
}
