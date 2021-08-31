using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDelegate : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public void UpdateUI()
    {
        onItemChanged?.Invoke();
    }
}
