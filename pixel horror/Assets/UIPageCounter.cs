using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPageCounter : MonoBehaviour
{
    float pages;
    public Text pagedText;
    public TestScriptableObject bookCount;

    void Update()
    {
        pages = bookCount.currHealth;
        pagedText.text = "PAGES: " + (int)pages;
    }
}
