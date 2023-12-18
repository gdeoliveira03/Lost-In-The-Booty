using Assets.Scripts.Player.Data;
using Assets.Scripts.Player.States.Movement.States.Airborne;
using Assets.Scripts.Player.States.Movement.States.Grounded;
using Assets.Scripts.Player.States.Movement.States.Grounded.Moving;

namespace Assets.Scripts.Player.States.Movement
{
    public class PlayerMovementStateMachine : Statemachine
    {
        public PlayerCharacter Player { get; }
        public PlayerReusableData ReusableData = new();
        public PlayerIdleState IdleState { get; }
        public PlayerRunState RunState { get; }
        public PlayerWalkState WalkState { get; }
        public PlayerAirborneState AirborneState { get; }
        public PlayerAttackState AttackState { get; }
        public PlayerMovementStateMachine(PlayerCharacter _player)
        {
            Player = _player;
            IdleState = new(this);
            WalkState = new(this);
            RunState = new(this);
            AirborneState = new(this);
            AttackState = new(this);
        }
    }
}
