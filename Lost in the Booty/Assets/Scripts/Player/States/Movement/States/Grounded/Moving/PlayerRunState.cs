using UnityEngine.InputSystem;
using UnityEngine;
using Assets.Scripts.Player.Animations;

namespace Assets.Scripts.Player.States.Movement.States.Grounded.Moving
{
    public class PlayerRunState : PlayerWalkState
    {
        public PlayerRunState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.Player.MyAnimator.SetBool(PlayerAnimations.RUN_ANIM_BOOL, true);
            stateMachine.ReusableData.MovementSpeedModifier = groundedData.RunSpeed;
            stateMachine.Player.MyInputMap.GroundedInputs.Run.canceled += OnRunCancelled;
        }
        public override void Exit()
        {
            base.Exit();
            stateMachine.Player.MyAnimator.SetBool(PlayerAnimations.RUN_ANIM_BOOL, false);
            stateMachine.Player.MyInputMap.GroundedInputs.Run.canceled -= OnRunCancelled;
        }
        #endregion
        #region Input Actions
        private void OnRunCancelled(InputAction.CallbackContext context)
        {
            if (stateMachine.ReusableData.MovementVector != Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.WalkState);
                return;
            }
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        #endregion
    }
}
