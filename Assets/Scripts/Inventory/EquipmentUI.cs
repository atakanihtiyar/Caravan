using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject panel;
    public EquipmentManager _equipmentManager;
    InventorySlot[] slots;

    private InventoryDelegate inventoryDelegate;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryDelegate = FindObjectOfType<InventoryDelegate>();
        inventoryDelegate.onItemChanged += UpdateUI;
    }

    public void ChangeActive(EquipmentManager equipmentManager)
    {
        _equipmentManager = equipmentManager;
        panel.SetActive(!panel.activeSelf);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (_equipmentManager == null) return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (_equipmentManager.currentEquipment[i] == null) return;

            if (i < _equipmentManager.currentEquipment.Length)
            {
                slots[i].AddItem(_equipmentManager.currentEquipment[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
