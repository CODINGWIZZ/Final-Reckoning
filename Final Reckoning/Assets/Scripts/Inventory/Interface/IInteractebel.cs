using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractebel
{
    public UnityAction<IInteractebel> OnInteractionComplete { get; set; }
    public void Interact(Interactor interactor, out bool interactionSuccessfull); 
    public void EndInteraction();
}
