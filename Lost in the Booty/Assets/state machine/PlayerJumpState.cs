using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    //constructor
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) {
        IsRootState = true;
        InitializeSubState(); // will be created regardless of which superState is active
    }

    public override void EnterState()
    {
        Ctx.Animator.SetBool(Ctx.IsJumpingHash, true);
        Ctx.IsJumpAnimating = true;
        Debug.Log("HELLO FROM jUMP STATE");
        HandleJump();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
        HandleGravity();
    }

    public override void ExitState()
    {
        Debug.Log("HELLO FROM JUMP STATE EXIT");
        Ctx.Animator.SetBool(Ctx.IsJumpingHash, false);
        Ctx.Animator.SetBool(Ctx.IsRunningHash, false);
        Ctx.IsJumpAnimating = false;
        
    }

    public override void InitializeSubState()
    {

    }

    public override void CheckSwitchStates()
    {
        if(Ctx.CharacterController.isGrounded)
        {
            SwitchStates(Factory.Grounded());
        }
    }

    void HandleJump() 
    {
        Ctx.Animator.SetBool(Ctx.IsJumpingHash, true);
        Ctx.IsJumpAnimating = true;
        Ctx.IsJumping = true;

        Ctx.CurrentMovementY = Ctx.InitialJumpVelocity * .5f;
        Ctx.CurrentRunMovementY = Ctx.InitialJumpVelocity *.5f;
    }

    void HandleGravity()
    {
        float previousYVelocity = Ctx.CurrentMovementY;
        float newYVelocity = Ctx.CurrentMovementY + (Ctx.Gravity * Time.deltaTime);
        float nextYvelocity = (previousYVelocity + newYVelocity) * .5f;

        Ctx.CurrentMovementY = nextYvelocity;
        Ctx.CurrentRunMovementY = nextYvelocity;
    }
}
