namespace Assets.Scripts.Player.States.Movement.States.Grounded.Moving
{
    public class PlayerDodgeState : PlayerGroundedState
    {
        public PlayerDodgeState(PlayerMovementStateMachine stateMachine)
            : base(stateMachine) { }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            Dodge();
        }

        protected override void AddInputActionsCallbacks()
        {
            //Override the parent input maps so we only leave this state when we want
            //e.g: Without this we would leave dodge state when Movement is canceled
        }

        protected override void RemoveInputActionsCallbacks()
        {
            //Override the parent input maps so we only leave this state when we want
            //e.g: Without this we would leave dodge state when Movement is canceled
        }
        #endregion

        #region Main Methods
        private void Dodge()
        {
            //TODO: Implemet dodge logic
            //Disable hitbox for a bit of time?
            //Push player in input direction with a Rigidbody Impulse Force?
        }
        #endregion
    }
}
