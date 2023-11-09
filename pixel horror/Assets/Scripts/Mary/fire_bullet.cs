using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_bullet : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;
    [SerializeField] private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;
    void Start()
    {
        InvokeRepeating("Fire", 0f, 1f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
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

            angle += angleStep;
        }
    }
}
