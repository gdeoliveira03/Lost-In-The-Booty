using Assets.Scripts.Player.Animations;
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
            stateMachine.Player.MyAnimator.SetBool(PlayerAnimations.WALK_ANIM_BOOL, false);
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
