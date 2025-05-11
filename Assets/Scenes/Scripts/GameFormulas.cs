using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        return attackElement == defender.GetWeakness();
    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        return attackElement == defender.GetResistance();
    }

    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
            return 1.5f;
        else if (HasElementDisadvantage(attackElement, defender))
            return 0.5f;
        else
            return 1f;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        int roll = Random.Range(0, 100);

        if (roll > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }

        return true;
    }

    public static bool IsCrit(int critValue)
    {
        int roll = Random.Range(0, 100);

        if (roll < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }

        return false;
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        // Somma le statistiche base e bonus dell'arma
        Stats attackerStats = SumStats(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defenderStats = SumStats(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());

        // Calcolo del danno base
        int attackValue = attackerStats.atk;
        int defenseValue;

        DAMAGE_TYPE dmgType = attacker.GetWeapon().GetDamageType();
        if (dmgType == DAMAGE_TYPE.PHYSICAL)
            defenseValue = defenderStats.def;
        else
            defenseValue = defenderStats.res;

        int damage = attackValue - defenseValue;

        // Modificatore elementale
        float modifier = EvaluateElementalModifier(attacker.GetWeapon().GetElement(), defender);
        damage = Mathf.RoundToInt(damage * modifier);

        // Colpo critico
        if (IsCrit(attackerStats.crt))
        {
            damage *= 2;
        }

        return Mathf.Max(damage, 0);
    }

    private static Stats SumStats(Stats a, Stats b)
    {
        return new Stats(
            a.atk + b.atk,
            a.def + b.def,
            a.res + b.res,
            a.spd + b.spd,
            a.crt + b.crt,
            a.aim + b.aim,
            a.eva + b.eva
        );
    }
}

