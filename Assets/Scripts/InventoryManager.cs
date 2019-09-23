using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    [Header("UI")]
    public Transform itemListParent;
    public GameObject listItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        FillItemList();
    }

    void FillItemList()
    {
        ClearList();
        //
        foreach (InventoryItem i in items)
        {
            ListItem item = Instantiate(listItemPrefab, itemListParent).GetComponent<ListItem>();
            item.FillItemInfo(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClearList()
    {
        foreach(Transform t in itemListParent)
        {
            Destroy(t.gameObject);
        }
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemTitle;
    [TextArea]
    public string itemDesc;
    public string itemPrice;
    [Space(10)]
    public List<Texture2D> itemImages = new List<Texture2D>();
    [Space(10)]
    public GameObject itemModelPrefab;
}