using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, ICharacter
{
    public EnemyStateMachine StateMachine { get; private set; }

    public int value = 100;

    [Inject] private InGameData gameData;

    [Inject] private EnemyStateMachineFactory _stateMachineFactory;

    [Inject] private EnemyData _enemyData;

    [Inject] public AnimationController AnimationController;

    [Inject] public Core Core { get; private set; }
    [Inject] public Animator Anim { get; private set; }
    [Inject] public Rigidbody2D RB { get; private set; }
    [Inject] public BoxCollider2D MovementCollider { get; private set; }
    [Inject] public Stats Stats { get; private set; }

    [Inject] private DamageReceiver damageReceiver;
    public EnemyData EnemyData { get => _enemyData; }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = _stateMachineFactory.CreateStateMachine(this, EnemyData, Core);

        Stats.Health.OnCurrentValueZero += GetPoints;

        AnimationController.SetAnim(Anim);

        damageReceiver.OnDamaged += HandleDamaged;
    }

    // Update is called once per frame
    void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
        Debug.Log(StateMachine.CurrentState);
    }

    void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void OnDestroy()
    {
        damageReceiver.OnDamaged -= HandleDamaged;
        Stats.Health.OnCurrentValueZero += GetPoints;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void HandleDamaged()
    {
        StateMachine.SwitchState(StateMachine.CurrentState, StateMachine.Factory.Damaged());
    }

    private void GetPoints()
    {
        gameData.points += value;
    }
}
