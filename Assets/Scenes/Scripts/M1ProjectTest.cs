using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero heroA;
    [SerializeField] private Hero heroB;

    private bool duelEnded = false;

    void Update()
    {
        HandleDuelTurn();
    }

    private void ExecuteAttack(Hero attacker, Hero defender)
    {
        Debug.Log(attacker.GetHeroName() + " attacca " + defender.GetHeroName());

        if (!GameFormulas.HasHit(attacker.GetBaseStats(), defender.GetBaseStats()))
            return;

        ELEMENT attackElement = attacker.GetWeapon().GetElement();

        if (GameFormulas.HasElementAdvantage(attackElement, defender))
        {
            Debug.Log("WEAKNESS");
        }
        else if (GameFormulas.HasElementDisadvantage(attackElement, defender))
        {
            Debug.Log("RESIST");
        }

        int damage = GameFormulas.CalculateDamage(attacker, defender);
        Debug.Log("Danno inflitto: " + damage);
        defender.TakeDamage(damage);
    }

    private void HandleDuelTurn()
    {
        if (duelEnded || heroA == null || heroB == null) return;
        if (!heroA.IsAlive() || !heroB.IsAlive()) return;

        Hero first, second;

        int heroASpeed = heroA.GetSpeed() + heroA.GetWeapon().GetBonusStats().spd;
        int heroBSpeed = heroB.GetSpeed() + heroB.GetWeapon().GetBonusStats().spd;

        if (heroASpeed >= heroBSpeed)
        {
            first = heroA;
            second = heroB;
        }
        else
        {
            first = heroB;
            second = heroA;
        }

        ExecuteAttack(first, second);

        if (!second.IsAlive())
        {
            Debug.Log("Vincitore: " + first.GetHeroName());
            duelEnded = true;
            return;
        }

        ExecuteAttack(second, first);

        if (!first.IsAlive())
        {
            Debug.Log("Vincitore: " + second.GetHeroName());
            duelEnded = true;
        }
    }
}
