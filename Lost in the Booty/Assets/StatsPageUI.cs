using Assets.Scripts;
using Assets.Scripts.Player;
using Assets.Scripts.Weapon;
using Assets.Scripts.Weapon.Weapons;
using UnityEngine;
using UnityEngine.UI;

public class StatsPageUI : MonoBehaviour
{
    [SerializeField]
    private Toggle Cutlass;

    [SerializeField]
    private Toggle Spear;

    [SerializeField]
    private Toggle Hammer;

    [SerializeField]
    private Toggle Fire;

    [SerializeField]
    private Toggle Ice;

    [SerializeField]
    private Toggle Lightning;

    PlayerCharacter playerCharacter = null;

    // Start is called before the first frame update
    void Start()
    {
        Cutlass.isOn = GameManager.Instance.scruffyInventory.Cutlass;
        Spear.isOn = GameManager.Instance.scruffyInventory.Spear;
        Hammer.isOn = GameManager.Instance.scruffyInventory.Hammer;
        Fire.isOn = GameManager.Instance.scruffyInventory.Fire;
        Ice.isOn = GameManager.Instance.scruffyInventory.Ice;
        Lightning.isOn = GameManager.Instance.scruffyInventory.Lightning;
        playerCharacter = GameObject.Find("scruffyMain").GetComponent<PlayerCharacter>();
        Cutlass.onValueChanged.AddListener(
            delegate
            {
                OnToggleChange(Cutlass);
            }
        );
        Spear.onValueChanged.AddListener(
            delegate
            {
                OnToggleChange(Spear);
            }
        );
        Hammer.onValueChanged.AddListener(
            delegate
            {
                OnToggleChange(Hammer);
            }
        );
        Fire.onValueChanged.AddListener(
            delegate
            {
                OnToggleChange(Fire);
            }
        );
        Ice.onValueChanged.AddListener(
            delegate
            {
                OnToggleChange(Ice);
            }
        );
        Lightning.onValueChanged.AddListener(
            delegate
            {
                OnToggleChange(Lightning);
            }
        );
    }

    private void OnToggleChange(Toggle change)
    {
        if (!change.isOn)
            return;

        if (change == Cutlass)
        {
            playerCharacter.MyInventory.EquipMeleeWeapon(WeaponType.SWORD);
            return;
        }
        if (change == Spear)
        {
            playerCharacter.MyInventory.EquipMeleeWeapon(WeaponType.SPEAR);
            return;
        }
        if (change == Hammer)
        {
            playerCharacter.MyInventory.EquipMeleeWeapon(WeaponType.HAMMER);
            return;
        }
        if (change == Fire)
        {
            //TODO: Equip Fire
            return;
        }
        if (change == Ice)
        {
            //TODO: Equip Ice
            return;
        }
        if (change == Lightning)
        {
            //TODO: Equip Lightning
            return;
        }
    }
}
