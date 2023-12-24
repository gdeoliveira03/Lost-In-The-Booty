using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class PlayerInventory
    {
        [SerializeField]
        public MeleeWeapon currentWeapon { get; private set; } = null;

        [SerializeField]
        public float Skulls { get; private set; } = 0f;

        [SerializeField]
        private bool initialized = false;

        public void EquipMeleeWeapon(MeleeWeapon newWeapon)
        {
            currentWeapon = newWeapon;
        }
    }
}
