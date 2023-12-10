using Assets.Scripts.Player.Data.Airborne;
using Assets.Scripts.Player.Data.Grounded;
using UnityEngine;

namespace Assets.Scripts.Player.Data
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player/Player")]
    public class PlayerSO : ScriptableObject
    {
        [field: SerializeField] public PlayerGroundedData GroundedData {  get; private set; }
        [field: SerializeField] public PlayerAirborneData AirborneData { get; private set; }
    }
}
