using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    public PlayerIdleState(PlayerStateMachine currentContext, string animBoolName) : base(currentContext, animBoolName)
    {
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

        if (!isExitingState)
        {
            if (xInput != 0)
            {
                _ctx.SwitchState(this, _ctx.Factory.Walk());
            }
            if (isAttacking)
            {
                _ctx.SwitchState(this, _ctx.Factory.Attack());
            }
        }
    }

    public override void PhysicsUpdate()
    {
        CheckAnim();
    }

    public void CheckAnim()
    {
        if (CurrentSuperState is PlayerGroundedState)
        {
            Player.AnimationController.SetAnim("Idle");
            Movement.SetVelocityX(Movement.RB.velocity.x * (1 - Time.deltaTime * Player.PlayerData.acceleration));
        }
        else
        {
            if (Player.AnimationController.GetCurrentAnim() != "FrontFlip")
            {
                if (Math.Abs(Player.RB.velocity.y) <= 1.3 && Player.AnimationController.GetCurrentAnim() != "JumpFall")
                {
                    Player.AnimationController.SetAnim("JumpMid");
                }
                else if (Player.RB.velocity.y > 1.3)
                {
                    Player.AnimationController.SetAnim("JumpRise");
                }
                else if (Player.RB.velocity.y < -1.3)
                {
                    Player.AnimationController.SetAnim("JumpFall");
                }

            }
            else
            {
                if (Player.AnimationController.IsAnimFinished())
                {
                    Player.AnimationController.SetAnim("JumpFall");
                }
            }

        }
    }
}
