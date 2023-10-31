using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) {}
    
    public override void EnterState()
    {
        Debug.Log("HELLO FROM GROUNDED STATE");
    }

    public override void UpdateState()
    {
        Debug.Log("HELLO FROM GROUNDED update STATE");
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
        // if player is grounded and jump is pressed switch to jump state
        if(_ctx.IsJumpPressed) {
            SwitchStates(_factory.Jump());
        }
    }
}
