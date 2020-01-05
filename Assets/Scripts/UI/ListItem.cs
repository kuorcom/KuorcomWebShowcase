using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour
{
    [Header("UI")]
    public Text titleTxt;
    public Text descTxt, priceTxt;
    public Image itemImg;
    Button itemBtn;

    // Start is called before the first frame update
    void Awake()
    {
        itemBtn = GetComponent<Button>();
    }

    public void FillItemInfo(InventoryItem inventoryItem, int itemIndex)
    {
        titleTxt.text = inventoryItem.itemTitle;
        descTxt.text = inventoryItem.itemDesc;
        priceTxt.text = "Price: $" + inventoryItem.itemPrice;

        itemImg.sprite = Sprite.Create(inventoryItem.itemImages[0], new Rect(0.0f, 0.0f, inventoryItem.itemImages[0].width, inventoryItem.itemImages[0].height), new Vector2(0.5f, 0.5f), 100.0f);

        itemBtn.onClick.AddListener(() => SceneManager.instance.PlaceItem(inventoryItem.itemModelPrefab, inventoryItem.colorOptions.Count > 1, inventoryItem.materialOptions.Count > 1));
        if (inventoryItem.colorOptions.Count > 1)
            itemBtn.onClick.AddListener(() => InventoryManager.instance.FillColorOptionsList(itemIndex));
        //
        if (inventoryItem.materialOptions.Count > 1)
            itemBtn.onClick.AddListener(() => InventoryManager.instance.FillMaterialOptionsList(itemIndex));
    }
}
