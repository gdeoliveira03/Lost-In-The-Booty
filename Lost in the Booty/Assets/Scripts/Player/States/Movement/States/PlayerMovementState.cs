using Assets.Scripts.Player.Data.Airborne;
using Assets.Scripts.Player.Data.Grounded;
using Assets.Scripts.Player.States.Movement.States.Airborne;
using UnityEngine;

namespace Assets.Scripts.Player.States.Movement.States
{
    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine stateMachine;
        protected PlayerGroundedData groundedData;
        protected PlayerAirborneData airborneData;
        protected float facingDirection;
        protected Quaternion targetRotation;
		private const float FLOOR_RAYCAST_OFFSET = 0.5f;
		private const float MAX_TO_FLOOR_CAST = 1.0f;

        public PlayerMovementState(PlayerMovementStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            groundedData = stateMachine.Player.Data.GroundedData;
            airborneData = stateMachine.Player.Data.AirborneData;
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
            if (!stateMachine.ReusableData.IsGrounded && stateMachine.CurrentState is not PlayerAirborneState)
            {
                stateMachine.ChangeState(stateMachine.AirborneState);
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
            LayerMask mask = LayerMask.GetMask("Ground");
            Vector3 PlayerToGroundOffset = stateMachine.Player.transform.position + Vector3.up * FLOOR_RAYCAST_OFFSET;
            return Physics.Raycast(PlayerToGroundOffset, Vector3.down, out RaycastHit hit, MAX_TO_FLOOR_CAST, mask);
        }
        #endregion

        #region Reusable Methods
        protected Vector3 GetVerticalVelocity()
        {
            return new Vector3(0f, stateMachine.Player.MyRigidbody.velocity.y, 0f);
        }
        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(stateMachine.ReusableData.MovementVector.x, 0f, stateMachine.ReusableData.MovementVector.y);
        }
        protected void ResetVelocity()
        {
            stateMachine.Player.MyRigidbody.velocity = Vector3.zero;
        }
        protected void RotatePlayerToFaceDirection()
        {
            stateMachine.Player.MyRigidbody.rotation = Quaternion.Lerp(stateMachine.Player.transform.rotation, targetRotation, Time.deltaTime * 6f);
        }
        protected void SnapToFaceDirection()
        {
            stateMachine.Player.MyRigidbody.rotation = Quaternion.Euler(0f, facingDirection, 0f);
            targetRotation = Quaternion.Euler(0f, facingDirection, 0f);
        }
        protected float GetGlobalFacingDirection(float horizontal, float vertical)
        {
            if ((vertical == 0f) && (horizontal == 0f))
            {
                return stateMachine.Player.transform.rotation.eulerAngles.y;
            }
            float y = stateMachine.Player.MyCamera.transform.rotation.eulerAngles.y;
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
            stateMachine.Player.MyRigidbody.rotation = Quaternion.Lerp(stateMachine.Player.gameObject.transform.rotation, targetRotation, Time.deltaTime * 6f);
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
