using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{

    public GameObject videoPlayer;
    public float timetoStop;


    void Start()
    {
        videoPlayer.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timetoStop);
        }
    }
}
