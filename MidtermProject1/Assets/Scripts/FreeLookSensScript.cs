using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class FreeLookSensScript : MonoBehaviour
{
    CinemachineFreeLook freeLook;
    public Slider horSlider;
    public Slider verSlider;

    void Start()
    {
        freeLook = gameObject.GetComponent<CinemachineFreeLook>();
        horSlider.onValueChanged.AddListener(delegate { HorValueChangeCheck(); });
        verSlider.onValueChanged.AddListener(delegate { VerValueChangeCheck(); });
    }

    public void HorValueChangeCheck()
    {
        freeLook.m_XAxis.m_MaxSpeed = horSlider.value;
    }
    public void VerValueChangeCheck()
    {
        freeLook.m_YAxis.m_MaxSpeed = verSlider.value;
    }
}
