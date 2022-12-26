using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assingedInventorySlot;

    private Button button;

    public InventorySlot AssingedInventorySlot => assingedInventorySlot;
    public InventoryDispaly ParentDispaly {get;private set;}

    private void Awake()
    {
        CleatSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDispaly = transform.parent.GetComponent<InventoryDispaly>();
    }

    public void init(InventorySlot slot)
    {
        assingedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if ( slot.ItamDats != null)
        {
            itemSprite.sprite = slot.ItamDats.icon;
            itemSprite.color = Color.white;

            if (slot.StackSize > 1)
            {
                itemCount.text = slot.StackSize.ToString();
            }
            else
            {
                itemCount.text = "";
            }

        }
        else
        {
            CleatSlot();
        }
    }

    public void UpdateUISlot()
    {
        if (assingedInventorySlot != null)
        {
            UpdateUISlot(assingedInventorySlot);
        }
    }

    public void CleatSlot()
    {
        assingedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = ""; 
    }

    public void OnUISlotClick()
    {
        ParentDispaly?.SlotClick(this);
    }
}
