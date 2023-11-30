using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageMScript : MonoBehaviour
{
    float collected;
    public GameObject PageM;

    void Start()
    {
        PageM = GameObject.FindWithTag("PageM");
        collected = PlayerPrefs.GetFloat("PageM");
        if (collected == 1f)
        {
            PageM.SetActive(false);
        }
    }
}
