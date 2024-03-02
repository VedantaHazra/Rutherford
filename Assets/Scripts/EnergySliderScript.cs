using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySliderScript : MonoBehaviour
{
    [SerializeField] Slider energySlider;
    private float value = 0f;
    void Awake()
    {
        value = 0f;
        energySlider.onValueChanged.AddListener(OnEnergySliderChanged);
    }

    private void OnEnergySliderChanged(float newEnergy)
    {
        value = newEnergy;
        Debug.Log(value);
    }

    public float GetValue()
    {
        return value;
    }
}
