using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem praimaryInvnetorySystem;

    public InventorySystem PraimarInvnetorySystem => praimaryInvnetorySystem;

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    protected virtual void Awake()
    {
        praimaryInvnetorySystem = new InventorySystem(inventorySize);
    }
}
