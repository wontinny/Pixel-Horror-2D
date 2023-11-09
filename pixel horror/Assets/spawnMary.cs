using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMary : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject videoPlayer;
    private BoxCollider2D BC;
    public float timetoStop;

    public GameObject Mary;


    void Start()
    {
        videoPlayer.SetActive(false);
        BC = GetComponent<BoxCollider2D>();
        BC.isTrigger = true;
        Mary.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Destroy(BC);
            Mary.SetActive(true);
        }

    }
}
