using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour, ICharacter
{

    public PlayerStateMachine StateMachine { get; private set; }

    [Inject] private PlayerStateMachineFactory _stateMachineFactory;
    [Inject] private PlayerCapabilityFactory _capabilityFactory;
    [Inject] private PlayerData _playerData;

    [Inject] public List<PlayerCapabilities> capabilities;

    [Inject] public AnimationController AnimationController;

    //[SerializeField] private PlayerData _playerData;

    //[SerializeField] private PlayerStateMachineFactory _factory;

    [Inject] private Ground _ground;

    #region Components
    [Inject] public Core Core { get; private set; }
    [Inject] public Animator Anim { get; private set; }
    [Inject] public PlayerInputHandler InputHandler { get; private set; }
    [Inject] public Rigidbody2D RB { get; private set; }
    [Inject] public BoxCollider2D MovementCollider { get; private set; }
    [Inject] public Stats Stats { get; private set; }
    [Inject] public InteractableDetector InteractableDetector { get; private set; }
    [Inject] private DamageReceiver damageReceiver;
    public PlayerData PlayerData { get => _playerData; }
    public Ground Ground { get => _ground; }
    #endregion

    #region Other Variables         

    [Inject(Id = "Primary")]
    private Weapon primaryWeapon;
    [Inject(Id = "Secondary")]
    private Weapon secondaryWeapon;

    #endregion

    private void Awake()
    {
        primaryWeapon?.SetCore(Core);
        secondaryWeapon?.SetCore(Core);

        capabilities?.Add(_capabilityFactory.GetJump(this, "JumpRise"));
        capabilities?.Add(_capabilityFactory.GetRoll(this, "Roll"));
        capabilities?.Add(_capabilityFactory.GetDash(this, "Dash"));

    }

    // Start is called before the first frame update
    void Start()
    {
        InputHandler.OnInteractInputChanged += InteractableDetector.TryInteract;
        StateMachine = _stateMachineFactory.CreateStateMachine(this, PlayerData, Core);

        if (gameObject.CompareTag("PlayerBase"))
        {
            Stats.Health.OnCurrentValueZero += GameOver;
        }

        AnimationController.SetAnim(Anim);
        damageReceiver.OnDamaged += HandleDamaged;
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.UpdateStates();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdateStates();
    }

    private void OnDestroy()
    {                           
        damageReceiver.OnDamaged -= HandleDamaged;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void HandleDamaged()
    {
        StateMachine.SwitchState(StateMachine.CurrentState, StateMachine.Factory.Damaged());
    }

    private void GameOver()
    {
        SceneManager.LoadSceneAsync(5);
    }

}

public enum Capability
{
    jump = 0,
    roll = 1,
    dash = 2
}
