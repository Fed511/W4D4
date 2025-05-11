using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;
    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }
}
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
