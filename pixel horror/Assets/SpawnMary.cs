using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMary : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mary;
    public GameObject MaryHealthBar;
    [SerializeField] private AudioSource sound;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Mary.SetActive(true);
            MaryHealthBar.SetActive(true);
            sound.Play();
            gameObject.SetActive(false);
        }

    }
}
