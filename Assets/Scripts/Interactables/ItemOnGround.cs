using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnGround : Interactable
{
    public Item item;
    public Vector3 rotation = new Vector3(0, -1, 0);
    
    private GameObject player;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0];
    }

    private void Update()
    {
        if (wasCollidedWithPlayer)
        {
            Inventory playerInventory = player.GetComponent<Inventory>();
            bool wasPickedUp = playerInventory.Add(item);

            if (wasPickedUp)
                Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(rotation);
    }
}
