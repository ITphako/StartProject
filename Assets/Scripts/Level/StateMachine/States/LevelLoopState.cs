
using Zenject;

 public class LevelLoopState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        private readonly IGameEventsListener _gameEventsListener;
        private readonly IGameEventsExecuter _gameEventsExecuter;

        public LevelLoopState(LevelStateMachine levelStateMachine, DiContainer diContainer)
        {
            _levelStateMachine = levelStateMachine;

            _gameEventsListener = diContainer.Resolve<IGameEventsListener>();
            _gameEventsExecuter = diContainer.Resolve<IGameEventsExecuter>();

            _gameEventsListener.LevelWin += OnLevelWin;
            _gameEventsListener.LevelLose += OnLevelLose;
        }

        public void Enter()
        {
            _gameEventsExecuter.OnLevelLoopEnter();
        }

        private void OnLevelWin()
        {
        }

        private void OnLevelLose()
        {
        }

        public void Exit()
        {
            _gameEventsListener.LevelWin -= OnLevelWin;
            _gameEventsListener.LevelLose -= OnLevelLose;
        }

    }