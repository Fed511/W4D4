using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[System.Serializable]
public class Hero : MonoBehaviour
{
    [SerializeField] private string heroName;
    [SerializeField] private int hp;
    [SerializeField] private int speed;
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
    public int GetSpeed()
    {
        return speed;
    }

  

    // Setters
    public void SetHeroName(string name)
    {
        heroName = name;
    }

    public void SetHP(int value)
    {
        hp = Mathf.Max(0, value); 
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
    public void SetSpeed(int value)
    {
        speed = value;
    }

    public void AddHp(int amount)
    {
        SetHP(hp + amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    void Start()
    {
        SetHP(Random.Range(50, 101));
        Debug.Log($"Hero: {heroName}, HP: {hp}");
    }

    void Update()
    {

    }
}
