using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public PlayerController player;
    [field: SerializeField] private float knockbackForce = 1f;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}