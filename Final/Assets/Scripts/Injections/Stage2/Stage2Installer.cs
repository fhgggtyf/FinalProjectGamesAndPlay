using UnityEngine;
using Zenject;

public class Stage2Installer : MonoInstaller
{
    [SerializeField] Player _player;

    public override void InstallBindings()
    {
        Container.BindInstances(_player);
    }
}
