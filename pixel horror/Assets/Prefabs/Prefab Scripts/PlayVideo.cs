using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{

    public GameObject videoPlayer;
    private BoxCollider2D BC;
    public float timetoStop;

    public GameObject theGhost;


    void Start()
    {
        videoPlayer.SetActive(false);
        BC = GetComponent<BoxCollider2D>();
        BC.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timetoStop);
            Destroy(BC);
            Instantiate(theGhost, transform.position, Quaternion.identity);
        }

    }
}
