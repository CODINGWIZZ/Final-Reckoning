using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItamData itemData;
    [SerializeField] private int stackSize;

    public InventoryItamData ItamDats => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryItamData source, int amoaunt)
    {
        itemData = source;
        stackSize = amoaunt;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItamData data, int amaunt)
    {
        itemData = data;
        stackSize = amaunt;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaning)
    {
        amountRemaning = itemData.MaxStackSize - stackSize;
         
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.MaxStackSize) return true;
        else return false;
    }   

    public void AddToStack(int amaount)
    {
        stackSize += amaount;
    }

    public void removeFromStack (int amaunt)
    {
        stackSize -= amaunt;
    }
}
