using UnityEngine;

namespace Assets.Scripts.Weapon.Weapons
{
    public class Sword : MeleeWeapon
    {
        public override void Use()
        {
            //TODO: Play the Sword animation
            Debug.Log(MyWeaponData.WeaponName);
        }
    }
}
