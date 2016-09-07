using UnityEngine;
using System.Collections;

public class IGUnitHandler {

	private InGameHandler _inGameHandler;

    public IGUnitHandler(InGameHandler IGH)
    {
        _inGameHandler = IGH;
    }

    public void Damage(Creature creature, int amount)
    {
        creature.Stats[Stat.Stat2] -= amount;
        if (creature.Stats[Stat.Stat2] <= 0)
        {
            Die(creature);
        }
    }

    public void Heal(Creature creature, int amount)
    {
        var realamount = Mathf.Min(creature.Base._stat2 - creature.Stats[Stat.Stat2], amount);
        creature.Stats[Stat.Stat2] += realamount;
    }

    public void Die(Creature creature)
    {
        Debug.Log("DIE IKKE LAVET ENDNU");
    }

    public void Attack(Creature attacker, Creature target)
    {
        Damage(attacker,target.Stats[Stat.Stat1]);
        Damage(target, attacker.Stats[Stat.Stat1]);
    }

}
