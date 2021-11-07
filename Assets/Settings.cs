using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    private AudioSource audioSrc;

    public Toggle toggleVolume;
    public Slider slider;
    public Text soundValue;

    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        slider.value = audioSrc.volume = PlayerPrefs.GetFloat("SaveVolume");
    }

    void Update()
    {

        soundValue.text = Mathf.Round(f: slider.value * 100) + "%";
    }

    public void SetVolume()
    {
        audioSrc.volume = slider.value;
        PlayerPrefs.SetFloat("SaveVolume", slider.value);
        if (slider.value > 0 && !toggleVolume.isOn)
        {
            //PlayerPrefs.SetFloat("VolumeBuf", 0f);
            toggleVolume.isOn = true;

        }

        if (slider.value == 0 && toggleVolume.isOn)
        {
            toggleVolume.isOn = false;
        }
    }
    public void SetVolumeZero()
    {
        if (slider.value > 0 && !toggleVolume.isOn)
        {
            PlayerPrefs.SetFloat("VolumeBuf", slider.value);
            PlayerPrefs.SetFloat("SaveVolume", 0f);
            audioSrc.volume = slider.value = 0f;
        }

        if (slider.value == 0 && toggleVolume.isOn)
        {
            audioSrc.volume = slider.value = PlayerPrefs.GetFloat("VolumeBuf");

        }
    }
}
