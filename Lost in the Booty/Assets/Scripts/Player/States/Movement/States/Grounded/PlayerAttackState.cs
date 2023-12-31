namespace Assets.Scripts.Player.States.Movement.States.Grounded
{
    public class PlayerAttackState : PlayerMovementState
    {
        public PlayerAttackState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region IState Methods
        public override void OnAnimationExitEvent()
        {
            base.OnAnimationExitEvent();
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        #endregion
    }
}
