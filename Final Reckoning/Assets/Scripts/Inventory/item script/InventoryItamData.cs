using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item ")]
public class InventoryItamData : ScriptableObject
{
    public Sprite icon;

    public string desplayName;
    [TextArea (4, 4)]
    public string description;

    public int ID;
    public int MaxStackSize;
}
