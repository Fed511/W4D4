using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public enum ELEMENT
{
    NONE,
    FIRE,
    ICE,
    LIGHTNING
}

public enum DAMAGE_TYPE
{
    PHYSICAL,
    MAGICAL
}

[System.Serializable]
public class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;
    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    // Getters
    public string GetWeaponName()
    {
        return weaponName;
    }

    public DAMAGE_TYPE GetDamageType()
    {
        return dmgType;
    }

    public ELEMENT GetElement()
    {
        return elem;
    }

    public Stats GetBonusStats()
    {
        return bonusStats;
    }

    // Setters
    public void SetWeaponName(string name)
    {
        weaponName = name;
    }

    public void SetDamageType(DAMAGE_TYPE type)
    {
        dmgType = type;
    }

    public void SetElement(ELEMENT element)
    {
        elem = element;
    }

    public void SetBonusStats(Stats stats)
    {
        bonusStats = stats;
    }

    void Start()
    {
        Debug.Log("Weapon: " + GetWeaponName() + ", Element: " + GetElement());
    }

    void Update()
    {

    }
}
