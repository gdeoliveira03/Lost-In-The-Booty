using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.States.Movement.States.Grounded
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }
        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            ResetVelocity();
        }
        public override void Update()
        {
            base.Update();
            if (stateMachine.ReusableData.MovementVector != Vector2.zero)
            {
                OnMove();
            }
        }
        #endregion
    }
}
