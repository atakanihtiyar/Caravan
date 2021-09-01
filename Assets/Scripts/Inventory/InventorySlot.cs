using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    public override void OnClick()
    {
        if (item == null)
            return;

        GameObject boxPanel = GameObject.FindGameObjectWithTag("BoxPanel");
        BoxUI boxUI = boxPanel.GetComponent<BoxUI>();

        GameObject playerPanel = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKey(KeyCode.LeftShift) && boxUI._inventory != null)
        {
            boxUI._inventory.Add(item);
            OnRemoveButton();
        }
        else
        {
            item.Use();
            OnRemoveButton();
        }
    }
}
