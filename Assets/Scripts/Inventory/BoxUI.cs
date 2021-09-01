using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUI : SlotUI
{
    protected override void Start()
    {
        base.Start();

        slots = itemsParent.GetComponentsInChildren<BoxSlot>();
    }
}
