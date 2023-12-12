using Assets.Scripts.Player.Animations;

namespace Assets.Scripts.Player.States.Movement.States.Airborne
{
    public class PlayerAirborneState : PlayerMovementState
    {
        public PlayerAirborneState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region IState Methods
        public override void Exit()
        {
            base.Exit();
            stateMachine.Player.MyAnimator.SetBool(PlayerAnimations.JUMP_BOOL, false);
        }
        public override void Update()
        {
            base.Update();
            if (stateMachine.ReusableData.IsGrounded) stateMachine.ChangeState(stateMachine.IdleState);
        }
        #endregion
    }
}
