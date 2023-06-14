using System.Collections;
using UnityEngine;
using Zenject;


 public class GameEventsInstaller : MonoInstaller
    {
        [SerializeField] private GameEvents _gameEvents;

        public override void InstallBindings()
        { 
            _gameEvents = new GameEvents();
            
            Container
                .Bind<IGameEventsListener>()
                .To<GameEvents>()
                .FromInstance(_gameEvents)
                .NonLazy();

            Container
                .Bind<IGameEventsExecuter>()
                .To<GameEvents>()
                .FromInstance(_gameEvents)
                .NonLazy();
        }
    }
