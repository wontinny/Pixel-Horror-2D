using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}