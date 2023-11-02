using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Code.UI;
using Code.Players;
using Code.Pooling;

public class GameplaySceneInstaller : MonoInstaller
{
    public UIController UIController;
    public Player Player;
    public ParticlesPooling ParticlesPooling;
    public ObjectPooling ObjectPooling;
    public GameStarter GameStarter;

    public override void InstallBindings()
    {
        Container.Bind<UIController>().FromInstance(UIController).AsSingle().NonLazy();
        Container.Bind<Player>().FromInstance(Player).AsSingle().NonLazy();
        Container.Bind<ParticlesPooling>().FromInstance(ParticlesPooling).AsSingle().NonLazy();
        Container.Bind<ObjectPooling>().FromInstance(ObjectPooling).AsSingle().NonLazy();
        Container.Bind<GameStarter>().FromInstance(GameStarter).AsSingle().NonLazy();
        
    }
}
