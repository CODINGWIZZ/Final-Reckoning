 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


[System.Serializable]
public class PlayerInventoryHolder : InventoryHolder
{
    [SerializeField] protected int secendaryInventorySize;
    [SerializeField] protected InventorySystem secendaryInventorySystem;

    public InventorySystem SecendaryInventorySystem => secendaryInventorySystem;

    public static UnityAction<InventorySystem> OnPlayerBackpackDesplayRequested;

    protected override void Awake()
    {
        base.Awake();

        secendaryInventorySystem = new InventorySystem(secendaryInventorySize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame) OnPlayerBackpackDesplayRequested?.Invoke(secendaryInventorySystem); 
    }

    public bool AddToInventory(InventoryItamData data, int amaont)
    {
        if (praimaryInvnetorySystem.AddToInventory(data, amaont))
        {
            return true;
        }
        else if (secendaryInventorySystem.AddToInventory(data,amaont))
        {
            return true;
        }

        return false;
    }
}
