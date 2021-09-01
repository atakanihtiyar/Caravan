using UnityEngine;

public class InventoryUI : SlotUI
{
    protected override void Start()
    {
        base.Start();

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
}
