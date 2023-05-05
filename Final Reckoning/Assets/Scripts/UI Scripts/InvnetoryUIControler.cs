using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvnetoryUIControler : MonoBehaviour
{
    public DynamicInvnetoryDisplay chestPanal;
    public DynamicInvnetoryDisplay playerBackpackPanal;

    private void Awake()
    {
        chestPanal.gameObject.SetActive(false);
        playerBackpackPanal.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDesplayRequested += DisplayPlayerBackpack;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDesplayRequested -= DisplayPlayerBackpack;
    }

    void Update()
    {
        if (chestPanal.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            chestPanal.gameObject.SetActive(false);
        }

        if (playerBackpackPanal.gameObject.activeInHierarchy && Keyboard.current.iKey.wasPressedThisFrame)
        {
            playerBackpackPanal.gameObject.SetActive(false);
        }
    }


    void DisplayInventory(InventorySystem invToDisplay)
    {
        chestPanal.gameObject.SetActive(true);
        chestPanal.RefreshDynamicInvntory(invToDisplay);
    }

    void DisplayPlayerBackpack(InventorySystem invToDisplay)
    {
        playerBackpackPanal.gameObject.SetActive(true);
        playerBackpackPanal.RefreshDynamicInvntory(invToDisplay);
    }
}
