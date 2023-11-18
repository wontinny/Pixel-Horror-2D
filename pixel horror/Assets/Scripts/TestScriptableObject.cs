using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestScriptableObject", menuName = "ScriptableObjects/TestScriptableObject")]
public class TestScriptableObject : ScriptableObject
{
    public float currHealth;

    public void changeCurrHealth(float change)
    {
        currHealth = change;
    }
}
