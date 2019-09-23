using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    [Header("Environment")]
    public int defaultEnv = 0;
    public List<Material> environments = new List<Material>();
    public ReflectionProbe envReflectionProbe;

    [Header("Sun")]
    public Transform sunTransform;
    Vector3 initSunRotation;

    [Header("UI")]
    public GameObject envChangePanel;
    public UnityEngine.UI.Image envButtonImg;
    bool isShowingEnvPanel = false;

    private void Start()
    {
        initSunRotation = sunTransform.eulerAngles;
    }

    public void ChangeEnvironment(int envIndex)
    {
        RenderSettings.skybox = environments[envIndex];
        DynamicGI.UpdateEnvironment();
        envReflectionProbe.RenderProbe();
    }

    public void ChangeButtonImg(UnityEngine.UI.Image sourceImg)
    {
        envButtonImg.sprite = sourceImg.sprite;
    }

    public void ChangeEnvRotation(float rotation)
    {
        foreach (Material env in environments)
        {
            env.SetFloat("_Rotation", rotation);
        }
        //
        DynamicGI.UpdateEnvironment();
        envReflectionProbe.RenderProbe();
    }
    public void ChangeEnvRotation(UnityEngine.UI.Slider slider)
    {
        foreach (Material env in environments)
        {
            env.SetFloat("_Rotation", slider.value);
        }
        //
        DynamicGI.UpdateEnvironment();
        envReflectionProbe.RenderProbe();
    }

    //

    public void ChangeSunRotation(float rotation)
    {
        sunTransform.eulerAngles = new Vector3(initSunRotation.x, rotation, initSunRotation.z);
    }
    public void ChangeSunRotation(UnityEngine.UI.Slider slider)
    {
        sunTransform.eulerAngles = new Vector3(initSunRotation.x, slider.value, initSunRotation.z);
    }

    //

    public void ToggleEnvPanel()
    {
        isShowingEnvPanel = !isShowingEnvPanel;
        envChangePanel.SetActive(isShowingEnvPanel);
    }
}
