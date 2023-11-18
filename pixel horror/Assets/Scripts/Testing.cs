using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] private TestScriptableObject testScriptableObject;

    void Start()
    {
        Debug.Log(testScriptableObject.currHealth);
    }

}
