using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageYScript : MonoBehaviour
{
    // Start is called before the first frame update

    float collected;
    public GameObject PageY;

    void Start()
    {
        PageY = GameObject.FindWithTag("PageY");
        collected = PlayerPrefs.GetFloat("PageY");
        if(collected == 1f)
        {
            PageY.SetActive(false);
        }
    }

    
}
