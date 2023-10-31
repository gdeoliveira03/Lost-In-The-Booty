using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) {}

    public override void EnterState()
    {
        Debug.Log("HELLO FROM jUMP STATE");
        HandleJump();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }

    public override void CheckSwitchStates()
    {

    }

    void HandleJump() 
    {
        _ctx.Animator.SetBool(_ctx.IsJumpingHash, true);
        _ctx.IsJumpAnimating = true;
        _ctx.IsJumping = true;

        _ctx.CurrentMovementY = _ctx.InitialJumpVelocity * .5f;
        _ctx.CurrentRunMovementY = _ctx.InitialJumpVelocity *.5f;
    }
}
