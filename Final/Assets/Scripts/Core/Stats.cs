using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Stats : CoreComponent
{
    [field: SerializeField] public Stat Health { get; private set; }
    [field: SerializeField] public Stat Poise { get; private set; }

    [Inject] public InGameData data;

    [SerializeField] private float poiseRecoveryRate;

    public HealthSystemForDummies healthInterface;
    protected override void Awake()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Health.Init();
            healthInterface.MaximumHealth = 0;
            healthInterface.AddToMaximumHealth(Health.MaxValue);
            healthInterface.CurrentHealth = Health.MaxValue;
            healthInterface.AddToCurrentHealth(Health.CurrentValue - Health.MaxValue);
        }
        else if (gameObject.CompareTag("Clone"))
        {
            Health.Init();
            healthInterface.MaximumHealth = 0;
            healthInterface.AddToMaximumHealth(Health.MaxValue);
            healthInterface.CurrentHealth = Health.MaxValue;
            healthInterface.AddToCurrentHealth(Health.CurrentValue - Health.MaxValue);
        }
        else
        {
            Health.Init(data.health);
            Health.MaxValue = data.MAXHEALTH;
            healthInterface.MaximumHealth = 0;
            healthInterface.AddToMaximumHealth(Health.MaxValue);
            healthInterface.CurrentHealth = Health.MaxValue;
            healthInterface.AddToCurrentHealth(Health.CurrentValue - Health.MaxValue);
        }

        Poise.Init();

        base.Awake();
    }

    private void Update()
    {
        if (Poise.CurrentValue.Equals(Poise.MaxValue))
            return;

        Poise.Increase(poiseRecoveryRate * Time.deltaTime);

    }
}
