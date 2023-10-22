using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int health = 100;

    [SerializeField] private Text Health;

   private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            health = health + 25;
            Health.text = "Health: " + health + "/100";
        }
    }

}
