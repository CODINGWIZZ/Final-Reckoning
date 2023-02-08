using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractebel
{
    public UnityAction<IInteractebel> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactionSuccessfull)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(praimaryInvnetorySystem);
        interactionSuccessfull = true;
    }

    public void EndInteraction()
    {

    }
}
