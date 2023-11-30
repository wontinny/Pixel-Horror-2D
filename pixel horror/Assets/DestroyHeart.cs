using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeart : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3.5f);
    }
}
