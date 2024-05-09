using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{

    bool _counterIncremented = true;
    List<string> _attacks = new List<string>();
    AttackInitializer _attack;

    public PlayerAttackState(PlayerStateMachine currentContext, string animBoolName) : base(currentContext, animBoolName)
    {
        _attacks.Add("SwordAttack");
        _attacks.Add("ComboAttack01"); 
        _attacks.Add("ComboAttack02");  
        _attacks.Add("ComboAttack03");     
        _attacks.Add("ComboAttack04");
        _attack = _core.GetCoreComponent<AttackInitializer>();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void EnterState()
    {
        base.EnterState();
        _attack.OnAttack();

    }

    public override void ExitState()
    {
        base.ExitState();
        _attack.OnAttackEnd();
    }


    public override void InitializeSubstate()
    {

    }

    public override void LogicUpdate()
    {

        DoChecks();

        if(!_attacks.Contains(Player.AnimationController.GetCurrentAnim()) || (_attacks.Contains(Player.AnimationController.GetCurrentAnim()) && Player.AnimationController.IsAnimFinished()))
        {
            if (!_counterIncremented)  {
                _attack.OnAttackEnd();
                _counterIncremented = true;
            }

            if (!isExitingState && !isAttacking)
            {
                if (xInput == 0)
                {
                    _ctx.SwitchState(this, _ctx.Factory.Idle());
                }
                else if (xInput != 0)
                {
                    _ctx.SwitchState(this, _ctx.Factory.Walk());
                }
            }
        }
        else
        {
            _counterIncremented = false;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        CheckAnim();

    }

    public void CheckAnim()
    {

        Debug.Log(_ctx.AttackCounter);
        if (CurrentSuperState is PlayerGroundedState)
        {
            Movement.SetVelocityX(Movement.RB.velocity.x * (1 - Time.deltaTime * Player.PlayerData.acceleration));
        }

        if (_counterIncremented)
        {
            _attack.OnAttack();
            Player.AnimationController.SetAnim(_attacks[_ctx.AttackCounter % 5]);
            _ctx.AttackCounter++;
            _counterIncremented = false;

        }

    }
}
