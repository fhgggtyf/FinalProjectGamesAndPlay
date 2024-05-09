using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : IStateMachine<EnemyBaseState>
{
    EnemyStateFactory _factory;

    Core _core;

    EnemyData _data;

    Enemy _enemy;

    int _attackCounter;

    public EnemyBaseState CurrentState { get; private set; }
    public Core Core { get => _core; set => _core = value; }
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    public EnemyData Data { get => _data; set => _data = value; }
    public EnemyStateFactory Factory { get => _factory; set => _factory = value; }
    public int AttackCounter { get => _attackCounter; set => _attackCounter = value; }

    public EnemyStateMachine(Enemy enemy, EnemyData data, Core core)
    {
        Factory = new EnemyStateFactory(this);
        Data = data;
        Core = core;
        Enemy = enemy;
        _attackCounter = 0;

        SetCurrentState(Factory.Idle());
        CurrentState.EnterState();
    }

    public void SetCurrentState(EnemyBaseState thisState)
    {
        CurrentState = thisState;
    }

    public void SwitchState(EnemyBaseState oldState, EnemyBaseState newState)
    {
        oldState.ExitState();

        newState.SetPrevState(oldState);

        SetCurrentState(newState);

        newState.EnterState();

    }
}
