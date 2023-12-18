using System;
using UnityEngine;

namespace Assets.Scripts.Player.Data.Grounded
{
    [Serializable]
    public class PlayerGroundedData
    {
        [field: SerializeField] public float WalkSpeed { get; set; } = 3.5f;
        [field: SerializeField] public float RunSpeed { get; set; } = 7f;
    }
}
