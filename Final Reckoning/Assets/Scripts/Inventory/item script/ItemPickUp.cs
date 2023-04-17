using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float pickUpRadius;
    public InventoryItamData ItemData;

    [SerializeField]
    private float _rotationSpeed;

    private SphereCollider myCollider;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = pickUpRadius;
    }

    private void Update()
    {
        transform.Rotate(eulers: Vector3.up * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
       
         if (!inventory) return;

        if (inventory.AddToInventory(ItemData, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
