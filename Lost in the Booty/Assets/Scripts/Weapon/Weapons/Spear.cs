using UnityEngine;

namespace Assets.Scripts.Weapon.Weapons
{
    public class Spear : MeleeWeapon
    {
        public Spear()
        {
            MyWeaponData = ScriptableObject.CreateInstance<WeaponData>();
            MyWeaponData.MyType = WeaponType.SPEAR;
        }

        public override void Use()
        {
            //TODO: Play the Spear animation
            Debug.Log(MyWeaponData.WeaponName);
        }
    }
}
