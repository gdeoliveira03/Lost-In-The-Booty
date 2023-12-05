using System.Collections;
using System.Collections.Generic;
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
        }
        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();
            stateMachine.Player.MyInputMap.GroundedInputs.Move.canceled -= OnMovementCancelled;
        }
        protected void OnMove()
        {
            stateMachine.ChangeState(stateMachine.RunState);
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
        #endregion
    }
}
