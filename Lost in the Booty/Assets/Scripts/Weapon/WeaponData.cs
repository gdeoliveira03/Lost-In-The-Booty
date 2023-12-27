using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public enum WeaponType
    {
        SWORD,
        SPEAR,
        HAMMER
    }

    [CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapon/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [field: SerializeField]
        public WeaponType MyType { get; private set; } = WeaponType.SWORD;

        [field: SerializeField]
        public string WeaponName { get; private set; } = "Dummy Name";

        [field: SerializeField]
        public float Damage { get; private set; } = 0f;
    }
}
