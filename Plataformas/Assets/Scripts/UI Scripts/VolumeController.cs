using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float volumeValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider(float value)
    {
        volumeValue = value;
        PlayerPrefs.SetFloat("audioVolume", volumeValue);
        AudioListener.volume = slider.value;
    }

}
