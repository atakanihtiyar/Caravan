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
}
