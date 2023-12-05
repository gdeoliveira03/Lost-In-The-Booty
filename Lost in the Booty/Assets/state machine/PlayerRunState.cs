using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.state_machine
{
    [Obsolete("Old state in old State Machine")]
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {

            Ctx.Animator.SetBool(Ctx.IsWalkingHash, true);
            Ctx.Animator.SetBool(Ctx.IsRunningHash, true);
            //Ctx.CurrentMovementX = 0;
            //Ctx.CurrentRunMovementX = 0;
            //Ctx.CurrentMovementZ = 0;
            //Ctx.CurrentRunMovementZ = 0;

        }

        public override void UpdateState()
        {
            CheckSwitchStates();

            Ctx.CurrentMovementX = Ctx.CurrentMovementInput.x * Ctx.RunMultiplier;
            Ctx.CurrentMovementZ = Ctx.CurrentMovementInput.y * Ctx.RunMultiplier;
            Debug.Log("We are running and moving at this speed: " + Ctx.CurrentMovementX);
            //Ctx.CurrentMovementY = 0.05f;
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
            // if walk not pressed, switch to idle
            if (!Ctx.IsMovementPressed)
            {
                SwitchStates(Factory.Idle());
            }
            // if walk but not run, switch to walk state
            else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
            {
                SwitchStates(Factory.Walk());
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
        }*/
    }
}
