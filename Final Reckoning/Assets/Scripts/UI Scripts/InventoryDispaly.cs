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
        //is schift down
        bool isSchiftPressed = Keyboard.current.leftShiftKey.isPressed;

        //click slot has item & mouse has no item 
        if(clickedUISlot.AssingedInventorySlot.ItamData != null && mouseInventoryItem.AssignedInventorySlot.ItamData == null)
        {

            //if shift is down -> split stack
            if (isSchiftPressed && clickedUISlot.AssingedInventorySlot.SplitStack(out InventorySlot halfStackSlot))
            {
                mouseInventoryItem.updateMouseSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            //if shift is up ->pick up item
            else
            {
                mouseInventoryItem.updateMouseSlot(clickedUISlot.AssingedInventorySlot);
                clickedUISlot.CleatSlot();
                return;
            }
        }

        //click slot has no item & mouse has item -> plase item
        if(clickedUISlot.AssingedInventorySlot.ItamData == null && mouseInventoryItem.AssignedInventorySlot.ItamData != null)
        {
            clickedUISlot.AssingedInventorySlot.AssignItemSlot(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
            return;
        }

        
        

        // click slot has item & mouse has item -> ...
        if (clickedUISlot.AssingedInventorySlot.ItamData != null && mouseInventoryItem.AssignedInventorySlot.ItamData != null) 
        {
            

            //check if muse item = clickt item
            bool isSameItem = clickedUISlot.AssingedInventorySlot.ItamData == mouseInventoryItem.AssignedInventorySlot.ItamData;

            // same item -> combind
            if (isSameItem && clickedUISlot.AssingedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))
            {
                clickedUISlot.AssingedInventorySlot.AssignItemSlot(mouseInventoryItem.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
                return;
            }

            // slot amount + mouse amoun > max stack sise -> take from mouse
            else if (isSameItem && 
                !clickedUISlot.AssingedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInStack))
            {
                //if stack = full -> swap
                if (leftInStack < 1)
                {
                    SwapSlots(clickedUISlot);
                    return;
                }

                //transfer fram mous item to clickt item untill stack is full
                else
                {
                    int remainingOnMouse = mouseInventoryItem.AssignedInventorySlot.StackSize - leftInStack;
                    clickedUISlot.AssingedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InventorySlot(mouseInventoryItem.AssignedInventorySlot.ItamData, remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.updateMouseSlot(newItem);
                    return;
                }

            }

            //diftent item -> swap
            else if (!isSameItem)
            {
                SwapSlots(clickedUISlot);
                return;
            }

        }
    }


    //swap [create a clon of mouse item. replases mouse item whith clickt item. replases the clickt item whith the clond item.]
    private void SwapSlots(InventorySlot_UI clicktUISlot)
    {
        var cloneSlot = new InventorySlot(mouseInventoryItem.AssignedInventorySlot.ItamData, mouseInventoryItem.AssignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.updateMouseSlot(clicktUISlot.AssingedInventorySlot);

        clicktUISlot.CleatSlot();
        clicktUISlot.AssingedInventorySlot.AssignItemSlot(cloneSlot);
        clicktUISlot.UpdateUISlot();
    }
}
