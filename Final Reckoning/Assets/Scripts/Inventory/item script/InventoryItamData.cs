using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// scriptebel objeckt
/// defines wath is an item
/// can hav diftent propertis (armor, potion, etc)
/// 
/// </summary>

[CreateAssetMenu(menuName = "Inventory System/Inventory Item ")]
public class InventoryItamData : ScriptableObject
{
    public Sprite icon;

    public string desplayName;
    [TextArea (4, 4)]
    public string description;

    public int ID;
    public int MaxStackSize;

    public bool dropt;

    public GameObject itemPrefab;

    
}
