using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius;
    public bool IsInteracting { get; private set; }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(InteractionPoint.position, InteractionPointRadius, InteractionLayer);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                var interactebel = colliders[i].GetComponent<IInteractebel>();

                if (interactebel != null)
                {
                    StartInteraction(interactebel);
                }
            }
        }
    }

    void StartInteraction(IInteractebel interactebel)
    {
        interactebel.Interact(this, out bool interactSucsessful);
        IsInteracting = true;
    }

    void EndInteraction()
    {
        IsInteracting = false;
    }
}

