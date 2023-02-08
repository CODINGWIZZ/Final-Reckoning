using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class dropItem : MonoBehaviour
{
    public PlayerInventoryHolder playerInventoryHolder; //= new PlayerInventoryHolder();
    int equip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HotbarEquip();
        Debug.Log(equip);

        //playerInventoryHolder.PraimarInvnetorySystem[equip];
    }

    public void HotbarEquip()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            equip = 0;
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            equip = 1;
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            equip = 2;
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            equip = 3;
        }
        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            equip = 4;
        }
        if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            equip = 5;
        }
        if (Keyboard.current.digit7Key.wasPressedThisFrame)
        {
            equip = 6;
        }
        if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            equip = 7;
        }
        if (Keyboard.current.digit9Key.wasPressedThisFrame)
        {
            equip = 8;
        }
        if (Keyboard.current.digit0Key.wasPressedThisFrame)
        {
            equip = 9;
        }
    }
}
