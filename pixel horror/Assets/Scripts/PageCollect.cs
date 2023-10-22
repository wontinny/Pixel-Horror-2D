using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCollect : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pages"))
        {
            Destroy(collision.gameObject);
        }
    }

}
