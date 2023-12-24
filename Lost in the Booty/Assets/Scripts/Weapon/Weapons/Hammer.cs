using UnityEngine;

namespace Assets.Scripts.Weapon.Weapons
{
    public class Hammer : MeleeWeapon
    {
        public Hammer()
        {
            MyWeaponData = ScriptableObject.CreateInstance<WeaponData>();
            MyWeaponData.MyType = WeaponType.SPEAR;
        }

        public override void Use()
        {
            //TODO: Play the Hamemr attack animation
            Debug.Log(MyWeaponData.WeaponName);
        }
    }
}
