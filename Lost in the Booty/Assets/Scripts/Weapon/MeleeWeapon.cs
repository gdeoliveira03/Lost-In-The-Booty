using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class MeleeWeapon : MonoBehaviour, IWeapon
    {
        [field: SerializeField]
        public WeaponData MyWeaponData { get; private set; }

        public virtual void Use() { }
    }
}
