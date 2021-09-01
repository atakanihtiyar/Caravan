using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    protected Item item;

    private SlotUI slotUI;

    private void Start()
    {
        slotUI = GetComponentInParent<SlotUI>();
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
        if (slotUI == null) return;

        slotUI._inventory.Remove(item);
    }


    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            OnRemoveButton();
        }
    }

    public virtual void OnClick()
    {

    }
}
