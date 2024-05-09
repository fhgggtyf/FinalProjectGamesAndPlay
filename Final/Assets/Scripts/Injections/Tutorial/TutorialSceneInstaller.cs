using UnityEngine;
using Zenject;

public class TutorialSceneInstaller : MonoInstaller
{
    [SerializeField] Player _player;
    [SerializeField] Enemy _enemy;

    public override void InstallBindings()
    {
        Container.BindInstances(_player, _enemy);
    }
}