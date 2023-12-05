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
            //TODO: Implement Move Logic
        }
        #endregion
    }
}
