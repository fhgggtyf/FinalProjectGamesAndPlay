using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IBaseState<EnemyBaseState>
{
    protected Core _core;

    EnemyBaseState _prevState;

    private Enemy _enemy;

    protected Movement Movement
    {
        get => movement ?? _core.GetCoreComponent(ref movement);
    }

    private Movement movement;

    protected CollisionSenses CollisionSenses
    {
        get => collisionSenses ?? _core.GetCoreComponent(ref collisionSenses);
    }

    private CollisionSenses collisionSenses;

    protected EnemyStateMachine _ctx;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string _animBoolName;

    public EnemyBaseState PrevState { get => _prevState; set => _prevState = value; }
    public Enemy Enemy { get => _enemy; set => _enemy = value; }

    public EnemyBaseState(EnemyStateMachine currentContext, string animBoolName)
    {

        _ctx = currentContext;
        _animBoolName = animBoolName;
        _core = currentContext.Core;
        Enemy = currentContext.Enemy;
    }

    public virtual void EnterState()
    {
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void ExitState()
    {
        isExitingState = true;
    }
    public virtual void DoChecks()
    {
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    public void SetPrevState(EnemyBaseState prevState)
    {
        PrevState = prevState;
    }

}
