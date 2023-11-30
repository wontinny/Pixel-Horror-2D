using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageAScript : MonoBehaviour
{
    float collected;
    public GameObject PageA;

    void Start()
    {
        PageA = GameObject.FindWithTag("PageA");
        collected = PlayerPrefs.GetFloat("PageA");
        if (collected == 1f)
        {
            PageA.SetActive(false);
        }
    }
}
