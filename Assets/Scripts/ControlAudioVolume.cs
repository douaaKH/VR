using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAudioVolume : MonoBehaviour
{
    public Slider volumeSlider;

    public void AdjustVolume()
    {
        float volume = volumeSlider.value;
        gameObject.GetComponent<AudioSource>().volume = volume;
    }

}
