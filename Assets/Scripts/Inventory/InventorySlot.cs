using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = GetComponentInParent<InventoryUI>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    
    public void OnRemoveButton()
    {
        if (inventoryUI == null) return;

        inventoryUI._inventory.Remove(item);
    }
    

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            OnRemoveButton();
        }
    }
}
