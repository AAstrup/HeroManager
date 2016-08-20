using System;
using System.Collections.Generic;

public class CardBalancer
{
    Dictionary<AbilityEvent, float> abilityEventCost;
    public CardBalancer()
    {
        abilityEventCost = new Dictionary<AbilityEvent, float>();

        abilityEventCost.Add(AbilityEvent.Battlecry, 1f);
        abilityEventCost.Add(AbilityEvent.Combo, 0.75f);
        abilityEventCost.Add(AbilityEvent.Deathrattle, 0.95f);

        abilityEventCost.Add(AbilityEvent.EndOfTurn, 3f);
        abilityEventCost.Add(AbilityEvent.EndOfYourTurn, 2f);
        abilityEventCost.Add(AbilityEvent.None, 1f);
        abilityEventCost.Add(AbilityEvent.StartOfTurn, 2.7f);
        abilityEventCost.Add(AbilityEvent.StartOfYourTurn, 1.8f);
    }
    public void BalanceCard(CardBase card)
    {
        if (card._cardType == CardType.Creature)
            BalanceCreature(card);
        else if (card._cardType == CardType.Spell)
            BalanceSpell(card);
        else if (card._cardType == CardType.Weapon)
            BalanceWeapon(card);
        else
            throw new Exception("No card type given!");
    }

    private void BalanceWeapon(CardBase card)
    {
        float totalCost = 0;
        //Stats
        totalCost += card._stat1 / 2;
        totalCost += card._stat2 / 2;

        //Abilities
        foreach (var ability in card._effects)
        {
            totalCost += ability.GetCost(abilityEventCost);
        }

        //Final, estimate cost among gem types
        EstimateCosts(card, totalCost);
    }

    private void BalanceSpell(CardBase card)
    {
        float totalCost = 0;

        //Abilities
        foreach (var ability in card._effects)
        {
            totalCost += ability.GetCost(abilityEventCost);
        }

        //Final, estimate cost among gem types
        EstimateCosts(card, totalCost);
    }

    private void BalanceCreature(CardBase card)
    {
        float totalCost = 0;
        //Stats
        totalCost += card._stat1 / 2;
        totalCost += card._stat2 / 2;

        if (card._creatureType != CreatureType.None)
            totalCost *= 1.1f;

        //Abilities
        foreach (var ability in card._effects)
        {
            totalCost += ability.GetCost(abilityEventCost);
        }

        //Final, estimate cost among gem types
        EstimateCosts(card,totalCost);
    }

    private void EstimateCosts(CardBase card, float totalCost)
    {
        float totalPercentage = 0;
        foreach (var currentCard in card._costs)
        {
            totalPercentage += (int)currentCard._percentageAmount;
        }

        List<int> debugList = new List<int>();
        foreach (var currentCard in card._costs)
        {
            if (currentCard._percentageAmount == 0)
                continue;
            float cal = currentCard._percentageAmount / totalPercentage;
            int rounded = (int)Math.Round(totalCost * cal, 0);
            currentCard.SetCost(rounded);
            debugList.Add(rounded);
        }
    }
}