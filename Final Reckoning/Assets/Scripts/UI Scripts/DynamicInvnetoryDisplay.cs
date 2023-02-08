using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInvnetoryDisplay : InventoryDispaly
{
    [SerializeField] protected InventorySlot_UI slotPrefab;
    protected override void Start()
    { 
        base.Start(); 
    }

    public void RefreshDynamicInvntory (InventorySystem invToDesplay)
    {
        clearSlot();
        inventorySystem = invToDesplay;
        if (inventorySystem != null)
        {
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        AssignSlot(invToDesplay);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    { 

        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();
        
        if(invToDisplay == null)
        {
            return;
        }

        
        for (int i = 0; i < invToDisplay.inventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDisplay.InventorySlots[i]);
            uiSlot.init(invToDisplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }
    }
    
    private void clearSlot()
    {
        foreach (var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }
        
        if (slotDictionary != null)
        {
            slotDictionary.Clear();
        }
    }

    private void OnDisable()
    {
        if (inventorySystem != null)
        {
            inventorySystem.OnInventorySlotChanged -= UpdateSlot;
        }
    }
}
