using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelInstance : MonoBehaviour
{
    
        private LevelStateMachine _levelStateMachine;

        private DiContainer _diContainer;
        private IGameEventsExecuter _gameEventsExecuter;


        [Inject]
        private void Construct(DiContainer diContainer, IGameEventsExecuter gameEventsExecuter)
        {
            _diContainer = diContainer;
            _gameEventsExecuter = gameEventsExecuter;
        }


        private void Awake()
        {
            _gameEventsExecuter.OnLevelBootstrap();

            _levelStateMachine = new LevelStateMachine( _diContainer);

            _levelStateMachine.Enter<LoadLevelState>();
        }

        private void OnDestroy()
        {
            _levelStateMachine.Enter<LevelDestroyState>();
        }
    
}
