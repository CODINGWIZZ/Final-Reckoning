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

    private void Awake()
    {
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";

        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }
}
