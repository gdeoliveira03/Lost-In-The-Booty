using UnityEngine;

namespace Assets.Scripts.Weapon.Weapons
{
    public class Hammer : MeleeWeapon
    {
        public override void Use()
        {
            //TODO: Play the Hamemr attack animation
            Debug.Log(MyWeaponData.WeaponName);
        }
    }
}
