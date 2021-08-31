using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public BodyPart bodyPart;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<EquipmentManager>().Equip(this);
    }
}

public enum BodyPart { Head, Chest, Legs, Weapon, Shield, Feet}