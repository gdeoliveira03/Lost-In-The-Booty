using System;
using UnityEngine;

namespace Assets.Scripts.Player.Data.Grounded
{
    [Serializable]
    public class PlayerGroundedData
    {
        [field: SerializeField] public float BaseSpeed { get; set; } = 7f;
    }
}
