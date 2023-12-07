using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.state_machine
{
    [Obsolete("Old State Machine")]
    public class PlayerWalkState : PlayerBaseState
    {
        public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {

            Ctx.Animator.SetBool(Ctx.IsWalkingHash, true);
            Ctx.Animator.SetBool(Ctx.IsRunningHash, false);
            //Ctx.CurrentMovementY = 0;
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            Ctx.CurrentMovementX = Ctx.CurrentMovementInput.x * Ctx.walkMultiplier;
            Ctx.CurrentMovementZ = Ctx.CurrentMovementInput.y * Ctx.walkMultiplier;

            //HandleGravity();
        }

        public override void ExitState()
        {

        }

        public override void InitializeSubState()
        {

        }

        public override void CheckSwitchStates()
        {
            // switch to idle if movement is no longer pressed
            if (!Ctx.IsMovementPressed)
            {
                SwitchStates(Factory.Idle());
            }
            // switch to run if run is pressed with movement
            else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
            {
                SwitchStates(Factory.Run());
            }
        }
        /*
        void HandleGravity()
        {
            float previousYVelocity = Ctx.CurrentMovementY;
            float newYVelocity = Ctx.CurrentMovementY + (Ctx.Gravity * Time.deltaTime);
            float nextYvelocity = (previousYVelocity + newYVelocity) * .5f;

            Ctx.CurrentMovementY = nextYvelocity;
            Ctx.CurrentRunMovementY = nextYvelocity;
        } */
    }
}
