using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItamData itemData;
    [SerializeField] private int stackSize;

    public InventoryItamData ItamData => itemData;
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

    public void AssignItemSlot(InventorySlot invSlot)
    {
        if(itemData == invSlot.ItamData)
        {
            AddToStack(invSlot.stackSize);
        }
        else
        {
            itemData = invSlot.itemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
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

    public void RemoveFromStack (int amaunt)
    {
        stackSize -= amaunt;
    }

    public bool SplitStack(out InventorySlot splitStack)
    {
        if(stackSize <= 1)
        {
            splitStack = null;
            return false;
        }

        int halfStack = Mathf.RoundToInt(stackSize / 2);
        RemoveFromStack(halfStack);

        splitStack = new InventorySlot(itemData, halfStack);
        return true;
    }
}