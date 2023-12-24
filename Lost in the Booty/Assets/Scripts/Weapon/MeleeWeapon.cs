namespace Assets.Scripts.Weapon
{
    public abstract class MeleeWeapon : IWeapon
    {
        public WeaponData MyWeaponData;

        public virtual void Use() { }
    }
}
