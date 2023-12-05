using Assets.Scripts.Player.Data;
using Assets.Scripts.Player.States.Movement.States.Grounded;
using Assets.Scripts.Player.States.Movement.States.Grounded.Moving;

namespace Assets.Scripts.Player.States.Movement
{
    public class PlayerMovementStateMachine : Statemachine
    {
        public PlayerCharacter Player { get; }
        public PlayerReusableData ReusableData = new PlayerReusableData();
        public PlayerIdleState IdleState { get; }
        public PlayerRunState RunState { get; }
        public PlayerMovementStateMachine(PlayerCharacter _player)
        {
            Player = _player;
            IdleState = new PlayerIdleState(this);
            RunState = new PlayerRunState(this);
        }
    }
}
