using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.States.Movement.States.Grounded.Moving
{
    public class PlayerWalkState : PlayerGroundedState
    {
        public PlayerWalkState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = groundedData.WalkSpeed;
            stateMachine.Player.MyInputMap.GroundedInputs.Run.started += OnRun;
        }
        public override void Exit()
        {
            base.Exit();
            stateMachine.Player.MyInputMap.GroundedInputs.Run.started -= OnRun;
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Move();
        }
        #endregion
        #region Main Methods
        private void Move()
        {
            Vector3 movementVector = GetMovementInputDirection();
            float resultAngle = GetGlobalFacingDirection(movementVector.x, movementVector.z);
            Vector3 zero = GetGlobalFacingVector3(resultAngle);
            float movementMagnitudeChecker = (movementVector.magnitude <= 0.95f) ? ((movementVector.magnitude >= 0.25f) ? movementVector.magnitude : 0f) : 1f;
            zero *= movementMagnitudeChecker;
            zero *= stateMachine.ReusableData.MovementSpeedModifier;
            if (resultAngle != -874f)
            {
                facingDirection = resultAngle;
                targetRotation = Quaternion.Euler(0f, facingDirection, 0f);
                Vector3 velocity = stateMachine.Player.MyRigidbody.velocity;
                Vector3 force = zero - velocity;

                force.x = Mathf.Clamp(force.x, -100f, 100f);
                force.z = Mathf.Clamp(force.z, -100f, 100f);
                force.y = 0f;
                stateMachine.Player.MyRigidbody.AddForce(force, ForceMode.VelocityChange);
                RotateToFaceDirection();
                stateMachine.Player.MyRigidbody.rotation = Quaternion.Lerp(stateMachine.Player.gameObject.transform.rotation, Quaternion.Euler(0f, facingDirection, 0f), Time.deltaTime * 10f);
            }
        }
        #endregion
        #region Input Actions
        private void OnRun(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.RunState);
        }
        #endregion
    }
}
