using System;
using UnityEngine;

public class DamageCalculator 
{
    public int CalculateDamage(int amount, float mitigationPercent)
    {
        float multiplier = 1f - mitigationPercent;
        return Convert.ToInt32(amount * multiplier);
    }

    public int CalculateDamage(int amount, ICharacter character)
    {
        int totalArmor = character.Inventory.GetArmor() + (character.Level * 10);
        float multiplier = 100f - totalArmor;
        multiplier /= 100f; //"Normalize"
        return Convert.ToInt32(amount * multiplier);
    }
}
