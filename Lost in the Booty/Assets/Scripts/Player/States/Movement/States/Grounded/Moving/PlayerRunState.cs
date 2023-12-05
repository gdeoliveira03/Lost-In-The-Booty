using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.States.Movement.States.Grounded.Moving
{
    public class PlayerRunState : PlayerGroundedState
    {
        public PlayerRunState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = groundedData.BaseSpeed;
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
            zero *= groundedData.BaseSpeed;
            if (resultAngle != -874f)
            {
                facingDirection = resultAngle;
                targetRotation = Quaternion.Euler(0f, facingDirection, 0f);
                Vector3 velocity = stateMachine.Player.myRigidbody.velocity;
                Vector3 force = zero - velocity;

                force.x = Mathf.Clamp(force.x, -100f, 100f);
                force.z = Mathf.Clamp(force.z, -100f, 100f);
                force.y = 0f;
                stateMachine.Player.myRigidbody.AddForce(force, ForceMode.VelocityChange);
                RotateToFaceDirection();
                stateMachine.Player.myRigidbody.rotation = Quaternion.Lerp(stateMachine.Player.gameObject.transform.rotation, Quaternion.Euler(0f, facingDirection, 0f), Time.deltaTime * 10f);
            }
        }
        #endregion
    }
}
