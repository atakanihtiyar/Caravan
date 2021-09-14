using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    public override void OnClick()
    {
        if (item == null)
            return;

        item.Use();
        OnRemoveButton();
    }
}
