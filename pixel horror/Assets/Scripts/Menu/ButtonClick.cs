using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource soundPlayer;

    public void playSound()
    {
        soundPlayer.Play();
    }
}
