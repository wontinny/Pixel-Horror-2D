using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    //[SerializeField] float keepHealth;              // Added LG
    public GameObject Player;
    public float x, y;
    // Level move zoned enter, if collider is a player
    // Move game to another scene
    int currScene;
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player");
        currScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if (other.tag == "Player")
        {
            if (currScene == 6)
            {
                float xchange = this.transform.position.x - Player.transform.position.x;
                float ychange = this.transform.position.y - Player.transform.position.y;
                x = Player.transform.position.x - xchange;
                y = Player.transform.position.y - ychange;
                print(x);
                print(y);
                PlayerPrefs.SetFloat("x", x);
                PlayerPrefs.SetFloat("y", y);
            }
            // Player entered, so move level
            //keepHealth = 20;
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            //PlayerController.changeHealth(keepHealth);
        }
    }
}
