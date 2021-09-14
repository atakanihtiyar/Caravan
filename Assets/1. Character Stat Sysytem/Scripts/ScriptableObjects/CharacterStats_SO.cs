using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New stat", menuName = "Character/Stat")]
public class CharacterStats_SO : ScriptableObject
{
    #region Fields

    public bool setManully = false;
    public bool saveDataOnClose = false;

    public ItemPickUp weapon { get; private set; }
    public ItemPickUp headArmor { get; private set; }
    public ItemPickUp chestArmor { get; private set; }
    public ItemPickUp handArmor { get; private set; }
    public ItemPickUp legArmor { get; private set; }
    public ItemPickUp footArmor { get; private set; }
    public ItemPickUp misc1 { get; private set; }
    public ItemPickUp misc2 { get; private set; }

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxStamina = 0;
    public int currentStamina = 0;

    public int maxWealth = 0;
    public int currentWealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0;
    public float currentResistance = 0;

    public float currentEmcumbrance = 0f;

    public int charExperience = 0;
    public int charLevel = 0;

    #endregion

    #region Increasers
    
    public void IncreaseHealth(int healthAmount)
    {
        if ((currentHealth + healthAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }
    
    public void IncreaseStamina(int staminaAmount)
    {
        if ((currentStamina + staminaAmount) > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else
        {
            currentStamina += staminaAmount;
        }
    }
    
    public void IncreaseWealth(int wealthAmount)
    {
        if ((currentWealth + wealthAmount) > maxWealth)
        {
            currentWealth = maxWealth;
        }
        else
        {
            currentWealth += wealthAmount;
        }
    }
    
    public void IncreaseDamage(int damageAmount)
    {
        currentDamage += damageAmount;
    }
    
    public void IncreaseResistance(int resistanceAmount)
    {
        currentResistance += resistanceAmount;
    }
    
    public void IncreaseEmcumbrance(int emcumbranceAmount)
    {
        currentEmcumbrance += emcumbranceAmount;
    }
    
    public void IncreaseExperience(int experienceAmount)
    {
        charExperience += experienceAmount;
    }
    
    public void IncreaseLevel(int levelAmount)
    {
        charLevel += levelAmount;
    }

    #endregion

    #region Decreasers

    public void DecreaseHealth(int healthAmount)
    {
        currentHealth -= healthAmount;
        if (currentHealth <= 0)
        {
            // TODO: Character death method
        }
    }

    public void DecreaseStamina(int staminaAmount)
    {
        currentStamina -= staminaAmount;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }

    public bool DecreaseWealth(int wealthAmount)
    {
        if ((currentWealth - wealthAmount) < maxWealth)
        {
            return false;
        }
        else
        {
            currentWealth -= wealthAmount;
            return true;
        }
    }

    public void DecreaseDamage(int damageAmount)
    {
        currentDamage -= damageAmount;
        if(currentDamage < 0)
        {
            currentDamage = 0;
        }
    }

    public void DecreaseResistance(int resistanceAmount)
    {
        currentResistance -= resistanceAmount;
        if (currentResistance < 0)
        {
            currentResistance = 0;
        }
    }

    public void DecreaseEmcumbrance(int emcumbranceAmount)
    {
        currentEmcumbrance -= emcumbranceAmount;
        if (currentEmcumbrance < 0)
        {
            currentEmcumbrance = 0;
        }
    }

    public void DecreaseExperience(int experienceAmount)
    {
        charExperience -= experienceAmount;
        if (charExperience < 0)
        {
            charExperience = 0;
        }
    }

    public void DecreaseLevel(int levelAmount)
    {
        charLevel -= levelAmount;
        if (charLevel < 0)
        {
            charLevel = 0;
        }
    }

    #endregion
}
