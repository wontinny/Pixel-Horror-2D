using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnMary : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mary;
    public GameObject MaryHealthBar;
    [SerializeField] private AudioSource sound;
    public GameObject transitionScene;
    public GameObject Player;
    public PlayerInput inputScript;
    Rigidbody2D playerRB;
    public GameObject sparkle;

    void Start()
    {
        this.Player = GameObject.FindWithTag("Player");
        inputScript = Player.GetComponent<PlayerInput>();
        playerRB = Player.GetComponent<Rigidbody2D>();
        sparkle.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Mary.SetActive(true);
            MaryHealthBar.SetActive(true);
            sound.Play();
            gameObject.SetActive(false);
            transitionScene.SetActive(true);
            sparkle.SetActive(false);
        }

    }
}
