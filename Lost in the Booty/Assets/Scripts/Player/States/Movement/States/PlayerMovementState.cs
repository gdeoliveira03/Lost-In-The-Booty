using Assets.Scripts.Player.Data.Grounded;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.States.Movement.States
{
    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine stateMachine;
        protected PlayerGroundedData groundedData;
        protected float facingDirection;
        protected Quaternion targetRotation;

        public PlayerMovementState(PlayerMovementStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            groundedData = stateMachine.Player.Data.GroundedData;
        }
        public virtual void Enter()
        {
            Debug.Log("State: " + GetType().Name);
            AddInputActionsCallbacks();
        }
        public virtual void Exit()
        {
            RemoveInputActionsCallbacks();
        }
        public virtual void HandleInput()
        {
            CheckGrounded();
            ReadMovementInput();
        }
        public virtual void OnAnimationEnterEvent()
        {
        }
        public virtual void OnAnimationExitEvent()
        {
        }
        public virtual void PhysicsUpdate()
        {
        }
        public virtual void Update()
        {
            if (!stateMachine.ReusableData.IsGrounded)
            {
                //TODO: Change to Airborne State?
            }
        }
        #region Main Methods
        private void ReadMovementInput()
        {
            stateMachine.ReusableData.MovementVector = stateMachine.Player.MyInputMap.GroundedInputs.Move.ReadValue<Vector2>();
        }
        private void CheckGrounded()
        {
            stateMachine.ReusableData.IsGrounded = IsGrounded();
        }
        private bool IsGrounded()
        {
            LayerMask mask = LayerMask.NameToLayer("Ground");
            return Physics.Raycast(stateMachine.Player.transform.position, Vector3.down, out RaycastHit hit, 0.3f, mask.value);
        }
        #endregion

        #region Reusable Methods
        protected Vector3 GetVerticalVelocity()
        {
            return new Vector3(0f, stateMachine.Player.myRigidbody.velocity.y, 0f);
        }
        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(stateMachine.ReusableData.MovementVector.x, 0f, stateMachine.ReusableData.MovementVector.y);
        }
        protected void ResetVelocity()
        {
            stateMachine.Player.myRigidbody.velocity = Vector3.zero;
        }
        protected void RotatePlayerToFaceDirection()
        {
            stateMachine.Player.myRigidbody.rotation = Quaternion.Lerp(stateMachine.Player.transform.rotation, targetRotation, Time.deltaTime * 6f);
        }
        protected void SnapToFaceDirection()
        {
            stateMachine.Player.myRigidbody.rotation = Quaternion.Euler(0f, facingDirection, 0f);
            targetRotation = Quaternion.Euler(0f, facingDirection, 0f);
        }
        protected float GetGlobalFacingDirection(float horizontal, float vertical)
        {
            if ((vertical == 0f) && (horizontal == 0f))
            {
                return stateMachine.Player.transform.rotation.eulerAngles.y;
            }
            float y = stateMachine.Player.myCamera.transform.rotation.eulerAngles.y;
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            angle = -angle + 90f;
            return (y + angle);
        }
        protected Vector3 GetGlobalFacingVector3(float resultAngle)
        {
            float num = -resultAngle + 90f;
            float x = Mathf.Cos(num * Mathf.Deg2Rad);
            return new Vector3(x, 0f, Mathf.Sin(num * Mathf.Deg2Rad));
        }
        protected void RotateToFaceDirection()
        {
            stateMachine.Player.myRigidbody.rotation = Quaternion.Lerp(stateMachine.Player.gameObject.transform.rotation, targetRotation, Time.deltaTime * 6f);
        }
        protected virtual void AddInputActionsCallbacks()
        {
        }
        protected virtual void RemoveInputActionsCallbacks()
        {
        }
        #endregion
    }
}
