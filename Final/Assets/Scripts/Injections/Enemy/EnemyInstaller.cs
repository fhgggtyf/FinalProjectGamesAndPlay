using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller<EnemyInstaller>
{
    [SerializeField] EnemyData _enemyData;
    [SerializeField] EnemyStateMachineFactory _EnemyStateMachineFactory;

    public override void InstallBindings()
    {
        Container.Bind<Core>().FromComponentInChildren().WhenInjectedInto<Enemy>();
        Container.Bind<Animator>().FromComponentInChildren().WhenInjectedInto<Enemy>();
        Container.Bind<Rigidbody2D>().FromComponentInHierarchy().WhenInjectedInto<Enemy>();
        Container.Bind<BoxCollider2D>().FromComponentInHierarchy().WhenInjectedInto<Enemy>();
        Container.Bind<Stats>().FromResolveGetter<Core>(core => core.GetCoreComponent<Stats>()).WhenInjectedInto<Enemy>();
        Container.Bind<DamageReceiver>().FromResolveGetter<Core>(core => core.GetCoreComponent<DamageReceiver>()).WhenInjectedInto<Enemy>();

        Container.Bind<AnimationController>().AsTransient().WhenInjectedInto<Enemy>();

        Container.BindInstances(_enemyData, _EnemyStateMachineFactory);
    }
}