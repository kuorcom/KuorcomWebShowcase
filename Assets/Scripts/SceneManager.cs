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

    public void PlaceItem(GameObject itemModel)
    {
        ClearPlacer();
        //
        Instantiate(itemModel, placerTransform);
        //
        if (popupGO.activeInHierarchy)
            popupGO.SetActive(false);
    }

    void ClearPlacer()
    {
        foreach(Transform t in placerTransform)
        {
            Destroy(t.gameObject);
        }
    }
}
