using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) {}

    public override void EnterState()
    {
        // change animator  booleans
        Ctx.Animator.SetBool(Ctx.IsWalkingHash, false);
        Ctx.Animator.SetBool(Ctx.IsRunningHash, false);
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
        // if walk and run pressed we switch to run state
        if(Ctx.IsMovementPressed && Ctx.IsRunPressed){
            SwitchStates(Factory.Run());
        }
        // if only walk is pressed, switch to walk state
        else if(Ctx.IsMovementPressed && !Ctx.IsRunPressed) {
            SwitchStates(Factory.Walk());
        }

    }
}
