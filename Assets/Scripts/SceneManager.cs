using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Singleton

    public static SceneManager instance;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    #endregion

    [Header("Placement")]
    public Transform placerTransform;

    [Header("UI")]
    public GameObject popupGO;

    // Start is called before the first frame update
    void Start()
    {
        ClearPlacer();
    }

    public void PlaceItem(GameObject itemModel, bool hasColors, bool hasMaterials)
    {
        ClearPlacer();
        //
        GameObject g = Instantiate(itemModel, placerTransform);
        //
        if (popupGO.activeInHierarchy)
            popupGO.SetActive(false);
        //
        if(g.TryGetComponent(out InventoryManager.instance.selectedItem))
        {
            InventoryManager.instance.SetOptionsButtonVisible(true);
        }
        else
        {
            InventoryManager.instance.SetOptionsButtonVisible(false);
        }

        InventoryManager.instance.SetColorOptionsVisible(hasColors);
        InventoryManager.instance.SetMaterialOptionsVisible(hasMaterials);
    }

    void ClearPlacer()
    {
        foreach(Transform t in placerTransform)
        {
            Destroy(t.gameObject);
        }
    }
}
