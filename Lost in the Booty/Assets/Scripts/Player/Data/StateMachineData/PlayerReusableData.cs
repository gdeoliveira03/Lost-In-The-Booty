using UnityEngine;

namespace Assets.Scripts.Player.Data
{
    public class PlayerReusableData
    {
        public Vector2 MovementVector { get; set; } = Vector2.zero;
        public bool IsGrounded { get; set; }
        public float MovementSpeedModifier = 0f;
    }
}