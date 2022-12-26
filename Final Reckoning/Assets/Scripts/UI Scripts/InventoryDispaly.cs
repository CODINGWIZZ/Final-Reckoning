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

    public void SlotClick(InventorySlot_UI clicdSlot)
    {
        Debug.Log("Slot clickt");
    }
}
