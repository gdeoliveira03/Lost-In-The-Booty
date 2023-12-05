using Assets.Scripts.Player.Data.Grounded;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Data
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player/Player")]
    public class PlayerSO : ScriptableObject
    {
        [field: SerializeField] public PlayerGroundedData GroundedData {  get; private set; }
    }
}
