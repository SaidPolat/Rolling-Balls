using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class CameraSettings : MonoBehaviour
{
    PostProcessLayer layer;
    public TMP_Dropdown aaDropdown;
    public static int dropdownValue = 3;

    void Start()
    {
        layer = gameObject.GetComponent<PostProcessLayer>();
        aaDropdown.onValueChanged.AddListener(delegate { AADropdownChange(); });
        Debug.Log(dropdownValue);
    }

    void Update()
    {
        if (dropdownValue == 0)
            layer.antialiasingMode = PostProcessLayer.Antialiasing.None;
        if (dropdownValue == 1)
            layer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        if (dropdownValue == 2)
            layer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
        if (dropdownValue == 3)
            layer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
    }
  
    public void AADropdownChange()
    {
        dropdownValue = aaDropdown.value;
  
    }
}
