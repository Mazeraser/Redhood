using UnityEngine;
using Zenject;
using Assets.Codebase.UI;

public class FadeInstallers : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Fade>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}