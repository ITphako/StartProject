
using Zenject;

 public class InitializeLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;
        private readonly IGameEventsExecuter _gameEventsExecuter;

        public InitializeLevelState(LevelStateMachine levelStateMachine, DiContainer diContainer)
        {
            _levelStateMachine = levelStateMachine;
            _gameEventsExecuter = diContainer.Resolve<IGameEventsExecuter>();
        }


        public void Enter()
        {
            _gameEventsExecuter.OnLevelInitialized();
            _gameEventsExecuter.OnLevelReady();

            _levelStateMachine.Enter<LevelLoopState>();
        }

        public void Exit()
        {

        }
    }