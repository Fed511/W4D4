using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[System.Serializable]
public class Hero : MonoBehaviour
{
    [SerializeField] private string heroName;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    // Getters
    public string GetHeroName()
    {
        return heroName;
    }

    public int GetHP()
    {
        return hp;
    }

    public Stats GetBaseStats()
    {
        return baseStats;
    }

    public ELEMENT GetResistance()
    {
        return resistance;
    }

    public ELEMENT GetWeakness()
    {
        return weakness;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    // Setters
    public void SetHeroName(string name)
    {
        heroName = name;
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }

    public void SetBaseStats(Stats stats)
    {
        baseStats = stats;
    }

    public void SetResistance(ELEMENT element)
    {
        resistance = element;
    }

    public void SetWeakness(ELEMENT element)
    {
        weakness = element;
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    void Start()
    {
        Debug.Log("Hero: " + GetHeroName() + ", HP: " + GetHP());
    }

    void Update()
    {

    }
}
