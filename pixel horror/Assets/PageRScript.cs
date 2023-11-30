using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageRScript : MonoBehaviour
{
    float collected;
    public GameObject PageR;

    void Start()
    {
        PageR = GameObject.FindWithTag("PageR");
        collected = PlayerPrefs.GetFloat("PageR");
        if (collected == 1f)
        {
            PageR.SetActive(false);
        }
    }
}
