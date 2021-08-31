using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 20;
    public List<Item> items = new List<Item>();

    private InventoryDelegate inventoryDelegate;

    public InventoryUI inventoryUI;
    
    private void Start()
    {
        inventoryDelegate = FindObjectOfType<InventoryDelegate>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory") && gameObject.tag == "Player")
        {
            inventoryUI.ChangeActive(this);
        }
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);
            inventoryDelegate.UpdateUI();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        inventoryDelegate.UpdateUI();
    }
}
