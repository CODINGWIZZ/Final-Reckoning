using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDesplay : InventoryDispaly
{
    [SerializeField]
    private InventoryHolder inventoryHolder;
    [SerializeField]
    private InventorySlot_UI[] slots;

    protected override void Start()
    {
        base.Start();

        if (inventoryHolder != null)
        {
            inventorySystem = inventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else
        {
            Debug.LogWarning("No inventory assignd to" + this.gameObject);
        }

        AssignSlot(inventorySystem);
    }
    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (slots.Length != inventorySystem.inventorySize) Debug.Log("inventory slot out of sync on" + this.gameObject);

        for (int i = 0; i < inventorySystem.inventorySize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].init(inventorySystem.InventorySlots[i]);   
        }
    }

   
}
