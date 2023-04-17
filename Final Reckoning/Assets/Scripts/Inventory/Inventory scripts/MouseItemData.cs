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

    public float dropOffcet;
    public float lift;
    public float dropforce;

    public Transform _playerTransform;

    public GameObject dropt;

    private Rigidbody rb;

    private void Awake()
    {
        ItemSprite.preserveAspect = true;
        ItemSprite.color = Color.clear;
        ItemCount.text = "";

        

    _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(_playerTransform == null)
        {
            Debug.Log("player not found");
        }
    }


    private void Start()
    {
    }
    public void updateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventorySlot.AssignItemSlot(invSlot);
        updateMouseSlot();
    }
    public void updateMouseSlot()
    {   
        ItemSprite.sprite = AssignedInventorySlot.ItamData.icon;
        ItemCount.text = AssignedInventorySlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }

    private void Update()
    {
        if (AssignedInventorySlot.ItamData != null)
        {
            transform.position = Mouse.current.position.ReadValue();
            if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObjeckt())
            {   
                if (AssignedInventorySlot.ItamData.itemPrefab != null)
                {
                    dropt = Instantiate(AssignedInventorySlot.ItamData.itemPrefab, _playerTransform.position + _playerTransform.forward * dropOffcet + _playerTransform.up + _playerTransform.up * lift, Quaternion.identity);
                    rb = dropt.gameObject.GetComponent<Rigidbody>();
                    dropt.transform.rotation = _playerTransform.rotation;
                    rb.AddForce(dropt.transform.forward * dropforce * Time.deltaTime + dropt.transform.up * dropforce * Time.deltaTime, ForceMode.Acceleration);
                }

                if (AssignedInventorySlot.StackSize > 1)
                {
                    AssignedInventorySlot.AddToStack(-1);
                    updateMouseSlot();
                }
                else
                {
                    ClearSlot();
                }
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

    public void closestItem()
    {
        
    }
}
