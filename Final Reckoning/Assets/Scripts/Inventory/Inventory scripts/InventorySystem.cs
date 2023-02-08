using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;

    public int inventorySize => inventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItamData itemToAdd, int amautToAdd)
    {
        if (ContainsItem(itemToAdd, out List <InventorySlot> inventorySlot)) // tittar när om objecktet är i inventoryt
        {
            foreach(var slot in inventorySlot)
            {
                if (slot.RoomLeftInStack(amautToAdd))
                {
                    slot.AddToStack(amautToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        
        if (HasFreeSlot(out InventorySlot freeSlot)) //tar första lediga platsen
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amautToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }

    public bool ContainsItem(InventoryItamData itemToAdd, out List<InventorySlot> inventorySlot)
    {
        inventorySlot = inventorySlots.Where(i => i.ItamData == itemToAdd).ToList();
        Debug.Log(inventorySlot.Count);
        return inventorySlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItamData == null);
        return freeSlot == null ? false : true;
    }
}
