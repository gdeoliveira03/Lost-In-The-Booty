using Assets.Scripts.Player.Animations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.States.Movement.States.Grounded
{
    public class PlayerGroundedState : PlayerMovementState
    {
        public PlayerGroundedState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region Reusable Methods
        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();
            stateMachine.Player.MyInputMap.GroundedInputs.Move.canceled += OnMovementCancelled;
            stateMachine.Player.MyInputMap.GroundedInputs.Jump.started += OnJumpStarted;
            stateMachine.Player.MyInputMap.GroundedInputs.Attack.started += OnAttackStarted;
            stateMachine.Player.MyInputMap.GroundedInputs.AbilityAttack.started += OnAbilityAttackStarted;
        }
        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();
            stateMachine.Player.MyInputMap.GroundedInputs.Move.canceled -= OnMovementCancelled;
            stateMachine.Player.MyInputMap.GroundedInputs.Jump.started -= OnJumpStarted;
        }
        protected void OnMove()
        {
            if (stateMachine.Player.MyInputMap.GroundedInputs.Run.inProgress)
            {
                stateMachine.ChangeState(stateMachine.RunState);
                return;
            }
            stateMachine.ChangeState(stateMachine.WalkState);
        }
        #endregion
        #region Input Methods
        private void OnDodgeStarted(InputAction.CallbackContext context)
        {
            //TODO: Change State to Dodging
        }
        private void OnMovementCancelled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        private void OnJumpStarted(InputAction.CallbackContext context)
        {
            stateMachine.Player.MyRigidbody.AddForce(Vector3.up * stateMachine.Player.Data.AirborneData.JumpForce, ForceMode.Impulse);
            stateMachine.Player.MyAnimator.SetBool(PlayerAnimations.JUMP_BOOL, true);
        }
        private void OnAttackStarted(InputAction.CallbackContext context)
        {
            if(stateMachine.CurrentState is not PlayerAttackState) stateMachine.ChangeState(stateMachine.AttackState);
        }
        private void OnAbilityAttackStarted(InputAction.CallbackContext context)
        {
            if (stateMachine.CurrentState is not PlayerAttackState) stateMachine.ChangeState(stateMachine.AttackState);
        }
        #endregion
    }
}
