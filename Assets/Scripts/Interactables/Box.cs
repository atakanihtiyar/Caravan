using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable
{
    public bool isOpen = false;
    private Animator animator;

    public BoxUI myInventoryUI;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        bool interactInput = Input.GetButtonDown("Interact");
        if (interactInput && wasCollidedWithPlayer)
        {
            Interact();
        }
    }

    public override void Interact()
    {
        base.Interact();

        isOpen = !isOpen;
        animator.SetBool("open", isOpen);

        Inventory myInventory = GetComponent<Inventory>();
        myInventoryUI.ChangeActive(myInventory);
    }
}
