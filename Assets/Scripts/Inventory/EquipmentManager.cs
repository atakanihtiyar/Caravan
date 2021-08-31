using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Equipment[] currentEquipment;
    Inventory inventory;

    public EquipmentUI equipmentUI;

    private void Start()
    {
        inventory = GetComponent<Inventory>();

        int numSlots = System.Enum.GetNames(typeof(BodyPart)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();

        if (Input.GetButtonDown("Inventory") && gameObject.tag == "Player")
        {
            equipmentUI.ChangeActive(this);
        }
    }

    public void Equip(Equipment newItem)
    {
        if (inventory == null) return;

        int slotIndex = (int)newItem.bodyPart;

        Unequip(slotIndex);

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (inventory == null) return;
        if (currentEquipment[slotIndex] == null) return;

        Equipment oldItem = currentEquipment[slotIndex];
        inventory.Add(oldItem);

        currentEquipment[slotIndex] = null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
