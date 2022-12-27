using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlot AssignedInventorySlot;

    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }
    public void updateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventorySlot.AssignItemSlot(invSlot);
        ItemSprite.sprite = invSlot.ItamDats.icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }

    private void Update()
    {
        if(AssignedInventorySlot.ItamDats != null)
        {
            transform.position = Mouse.current.position.ReadValue();
            if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObjeckt())
            {
                ClearSlot();
            }
        }
    }

    public void ClearSlot()
    {
        AssignedInventorySlot.ClearSlot();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    public static bool IsPointerOverUIObjeckt()
    {
        PointerEventData enventDataCurrentPosition = new PointerEventData(EventSystem.current);
        enventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(enventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
