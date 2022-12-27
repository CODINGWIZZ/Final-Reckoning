using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDispaly : MonoBehaviour
{
    [SerializeField]
    MouseItemData mouseInventoryItem;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;


    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;
    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void Start()
    {

    }

    protected virtual void UpdateSlot(InventorySlot updateSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if(slot.Value == updateSlot)// Slot value - the "under the hood" inventory slot.
            {
                slot.Key.UpdateUISlot(updateSlot); //slot key - the ui representation of the value
            }
        }
    }

    public void SlotClick(InventorySlot_UI clickedUISlot)
    {
        //click slot has item & mouse has no item  -> pick upp item

        if(clickedUISlot.AssingedInventorySlot.ItamDats != null && mouseInventoryItem.AssignedInventorySlot.ItamDats == null)
        {
            // click + schift -> split stack

            mouseInventoryItem.updateMouseSlot(clickedUISlot.AssingedInventorySlot);
            clickedUISlot.CleatSlot();
            return;
        }

        //click slot has no item & mouse has item -> plase item

        if(clickedUISlot.AssingedInventorySlot.ItamDats == null && mouseInventoryItem.AssignedInventorySlot.ItamDats != null)
        {
            clickedUISlot.AssingedInventorySlot.AssignItemSlot(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        // click slot has item & mouse has item -> ...
        // same item -> combind
        // slot amount + mouse amoun > max stack sise -> take from mouse
        //diftent item -> swap
    }
}
