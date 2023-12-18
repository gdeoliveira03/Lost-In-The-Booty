namespace Assets.Scripts.Player
{
    public abstract class Statemachine
    {
        public IState CurrentState { get; protected set; }
        public IState PreviousState { get; protected set; }

        public void ChangeState(IState newState)
        {
            PreviousState = CurrentState;
            CurrentState?.Exit();
            newState?.Enter();
            CurrentState = newState;
        }
        public void HandleInput()
        {
            CurrentState?.HandleInput();
        }
        public void Update()
        {
            CurrentState?.Update();
        }
        public void PhysicsUpdate()
        {
            CurrentState?.PhysicsUpdate();
        }

        public void OnAnimationEnterEvent()
        {
            CurrentState?.OnAnimationEnterEvent();
        }
        public void OnAnimationExitEvent()
        {
            CurrentState?.OnAnimationExitEvent();
        }
    }
}
