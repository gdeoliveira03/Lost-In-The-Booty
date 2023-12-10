using System;
using UnityEngine;

namespace Assets.Scripts.Player.Data.Airborne
{
    [Serializable]
    public class PlayerAirborneData
    {
        [field: SerializeField] public float JumpForce { get; set; } = 600f;
    }
}
