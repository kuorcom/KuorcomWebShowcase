using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseItem : MonoBehaviour
{
    [Header("Config")]
    public bool offsetAtStart = false;
    public Vector3 placerPositionOffset = Vector3.zero;
    public Vector3 placerRotationOffset = Vector3.zero;

    [Header("Option Change")]
    public List<MeshRenderer> meshesToChange = new List<MeshRenderer>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (offsetAtStart)
        {
            transform.localPosition = placerPositionOffset;
            transform.localEulerAngles = placerRotationOffset;
        }
    }

    public void ChangeColor(Color newColor)
    {
        foreach(MeshRenderer m in meshesToChange)
        {
            m.material.SetColor("_Color", newColor);
        }
    }

    public void ChangeMaterial(Material newMaterial)
    {
        foreach (MeshRenderer m in meshesToChange)
        {
            m.material = newMaterial;
        }
    }
}
