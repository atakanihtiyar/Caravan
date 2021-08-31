using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject panel;
    public Inventory _inventory;
    InventorySlot[] slots;

    private InventoryDelegate inventoryDelegate;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryDelegate = FindObjectOfType<InventoryDelegate>();
        inventoryDelegate.onItemChanged += UpdateUI;
    }

    public void ChangeActive(Inventory inventory)
    {
        _inventory = inventory;
        panel.SetActive(!panel.activeSelf);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (_inventory == null) return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < _inventory.items.Count)
            {
                slots[i].AddItem(_inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
