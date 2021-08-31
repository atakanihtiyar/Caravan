using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnGround : MonoBehaviour
{
    public Item item;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool wasPickedUp = other.GetComponent<Inventory>().Add(item);

            if (wasPickedUp)
                Destroy(gameObject);
        }
    }
}
