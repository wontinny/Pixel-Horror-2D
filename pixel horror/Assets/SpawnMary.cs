using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMary : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mary;


    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Mary.SetActive(true);
        }

    }
}
