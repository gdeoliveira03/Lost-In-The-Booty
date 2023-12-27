using Assets.Scripts.Weapon;
using Assets.Scripts.Weapon.Weapons;
using UnityEngine;

[CreateAssetMenu(fileName = "scruffy Inventory", menuName = "Player/Inventory")]
public class ScruffyInventory : ScriptableObject
{
    public bool Cutlass = true;
    public bool Spear = false;
    public bool Hammer = false;
    public bool Lightning = false;
    public bool Ice = false;
    public bool Fire = false;

    public int Skulls { get; private set; } = 0;
    public int Coins { get; private set; } = 0;

    private bool weaponsInitialized = false;
    public MeleeWeapon CurrentWeapon { get; private set; } = null;
    private MeleeWeapon[] myWeapons = new MeleeWeapon[3];

    public void InitializeStats(int _skulls = 0, int _coins = 0)
    {
        Skulls = _skulls;
        Coins = _coins;
    }

    public void InitializeWeapons(Sword _sword, Spear _spear, Hammer _hammer)
    {
        myWeapons[0] = _sword;
        myWeapons[1] = _spear;
        myWeapons[2] = _hammer;
        weaponsInitialized = true;
    }

    public void EquipMeleeWeapon(WeaponType weapon)
    {
        if (!weaponsInitialized)
        {
            Debug.LogError(
                "[ScruffyInventory] Tried to equip a weapon without initializing weapon references"
            );
        }
        switch (weapon)
        {
            case WeaponType.SWORD:
                CurrentWeapon = myWeapons[0];
                break;
            case WeaponType.SPEAR:
                CurrentWeapon = myWeapons[1];
                break;
            case WeaponType.HAMMER:
                CurrentWeapon = myWeapons[2];
                break;
            default:
                CurrentWeapon = myWeapons[0];
                break;
        }
    }

    public void AddSkulls(int amount)
    {
        Skulls += amount;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
    }
}
