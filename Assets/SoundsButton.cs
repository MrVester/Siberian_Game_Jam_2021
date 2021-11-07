using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsButton : MonoBehaviour
{
    public AudioSource Sounds;

    public AudioClip hover;
    public AudioClip click;

    public void HoverSound()
    {
        Sounds.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        Sounds.PlayOneShot(click);
    }
}
