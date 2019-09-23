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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillItemInfo(InventoryItem inventoryItem)
    {
        titleTxt.text = inventoryItem.itemTitle;
        descTxt.text = inventoryItem.itemDesc;
        priceTxt.text = "Price: $" + inventoryItem.itemPrice;

        itemImg.sprite = Sprite.Create(inventoryItem.itemImages[0], new Rect(0.0f, 0.0f, inventoryItem.itemImages[0].width, inventoryItem.itemImages[0].height), new Vector2(0.5f, 0.5f), 100.0f);

        itemBtn.onClick.AddListener(() => SceneManager.instance.PlaceItem(inventoryItem.itemModelPrefab));
    }
}
