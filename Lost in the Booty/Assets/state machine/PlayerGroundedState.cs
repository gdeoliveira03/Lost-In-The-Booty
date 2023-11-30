using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    // constructor
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) {
        IsRootState = true;
        InitializeSubState(); // will be created regardless of which superState is active
    }
    
    public override void EnterState()
    {
        Ctx.CurrentMovementY = Ctx.GroundedGravity;
        Ctx.CurrentRunMovementY = Ctx.GroundedGravity;
    }

    public override void UpdateState()
    {
        // if not grounded but in grounded state apply gravity
        if(Ctx.CharacterController.isGrounded == false)
        {
            HandleGravity();
        }
        
        CheckSwitchStates();

    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {
        // if not moving or running create idle substate
        if(!Ctx.IsMovementPressed && !Ctx.IsRunPressed) {
            SetSubState(Factory.Idle());
        }
        // this is where problem is ********

        // if movement pressed but not run switch to walk
        else if(Ctx.IsMovementPressed && !Ctx.IsRunPressed) {
            if(!Ctx.IsJumpPressed) {
                SetSubState(Factory.Walk());
            }
            
        }
        else {
            if(!Ctx.IsJumpPressed) {
                SetSubState(Factory.Run());
            }
            
        }
    }

    public override void CheckSwitchStates()
    {
        // if player is grounded and jump is pressed switch to jump state
        if(Ctx.IsJumpPressed) {
            SwitchStates(Factory.Jump());
        }
    }

    void HandleGravity()
    {
        float previousYVelocity = Ctx.CurrentMovementY;
        float newYVelocity = Ctx.CurrentMovementY + (Ctx.Gravity * Time.deltaTime);
        float nextYvelocity = (previousYVelocity + newYVelocity) * .5f;
        nextYvelocity = -5.0f;
        Ctx.CurrentMovementY = nextYvelocity;
        Ctx.CurrentRunMovementY = nextYvelocity;
    }

    
}
