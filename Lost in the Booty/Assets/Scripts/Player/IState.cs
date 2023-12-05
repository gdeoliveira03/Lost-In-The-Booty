namespace Assets.Scripts.Player
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void HandleInput();
        public void PhysicsUpdate();
        public void Update();
        public void OnAnimationEnterEvent();
        public void OnAnimationExitEvent();
    }
}
