using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSlot : Slot
{
    public override void OnClick()
    {
        if (item == null)
            return;

        GameObject boxPanel = GameObject.FindGameObjectWithTag("BoxPanel");
        BoxUI boxUI = boxPanel.GetComponent<BoxUI>();

        GameObject playerPanel = GameObject.FindGameObjectWithTag("Player");
        Inventory playerInventory = playerPanel.GetComponent<Inventory>();

        if (Input.GetKey(KeyCode.LeftShift) && boxUI._inventory != null)
        {
            playerInventory.Add(item);
            OnRemoveButton();
        }
        else
        {
            item.Use();
            OnRemoveButton();
        }
    }
}
