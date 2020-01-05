using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager instance = null;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    #endregion

    public List<InventoryItem> items = new List<InventoryItem>();

    public ShowcaseItem selectedItem;

    [Header("UI")]
    public Transform itemListParent;
    public GameObject listItemPrefab;

    [Header("Options")]
    bool optionsIsVisible = false;
    public Transform colorOptionListParent;
    public Transform materialOptionListParent;
    public GameObject optionButtonPrefab;
    public GameObject optionsButton;
    public GameObject optionPanel;

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
            item.FillItemInfo(i, items.IndexOf(i));
        }
    }

    public void FillColorOptionsList(int itemIndex)
    {
        ClearList(colorOptionListParent);
        //
        if(!colorOptionListParent.gameObject.activeInHierarchy)
            colorOptionListParent.gameObject.SetActive(true);
        //
        foreach(Color c in items[itemIndex].colorOptions)
        {
            OptionItem opt = Instantiate(optionButtonPrefab, colorOptionListParent).GetComponent<OptionItem>();
            opt.optionImg.color = c;
            opt.optionBtn.onClick.AddListener(() => selectedItem.ChangeColor(c));
        }
    }
    public void FillMaterialOptionsList(int itemIndex)
    {
        ClearList(materialOptionListParent);
        //
        if (!materialOptionListParent.gameObject.activeInHierarchy)
            materialOptionListParent.gameObject.SetActive(true);
        //
        foreach (Material m in items[itemIndex].materialOptions)
        {
            OptionItem opt = Instantiate(optionButtonPrefab, materialOptionListParent).GetComponent<OptionItem>();
            Texture2D t = m.GetTexture("_MainTex") as Texture2D;
            opt.optionImg.sprite = Sprite.Create(t, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
            opt.optionBtn.onClick.AddListener(() => selectedItem.ChangeMaterial(m));
        }
    }
    //
    public void SetColorOptionsVisible(bool visible)
    {
        colorOptionListParent.gameObject.SetActive(visible);
    }
    public void SetMaterialOptionsVisible(bool visible)
    {
        materialOptionListParent.gameObject.SetActive(visible);
    }

    void SetOptionsPanelActive(bool visible)
    {
        optionPanel.SetActive(visible);
        optionsIsVisible = visible;
    }
    public void ToggleOptionsPanel()
    {
        optionsIsVisible = !optionsIsVisible;
        optionPanel.SetActive(optionsIsVisible);
    }

    public void SetOptionsButtonVisible(bool visible)
    {
        optionsButton.SetActive(visible);
    }

    void ClearList()
    {
        foreach(Transform t in itemListParent)
        {
            Destroy(t.gameObject);
        }
    }
    void ClearList(Transform listTransform)
    {
        foreach (Transform t in listTransform)
        {
            Destroy(t.gameObject);
        }
    }
}

[System.Serializable]
public class InventoryItem
{
    [Header("Item Info")]
    public string itemTitle;
    [TextArea]
    public string itemDesc;
    public string itemPrice;
    [Space(10)]
    public List<Texture2D> itemImages = new List<Texture2D>();
    [Header("Item Options")]
    public List<Material> materialOptions = new List<Material>();
    public List<Color> colorOptions = new List<Color>();
    [Space(10)]
    public GameObject itemModelPrefab;
}