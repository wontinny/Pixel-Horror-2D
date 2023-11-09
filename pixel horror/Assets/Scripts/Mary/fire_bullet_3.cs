using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_bullet_3 : MonoBehaviour
{
    private float angle = 180f;
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = bullet_pool.bulletPoolInstanse.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<bullet_hell>().SetMoveDirection(bulDir);

        angle += 10f;
    }
   
}
