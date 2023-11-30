using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHallDoor : MonoBehaviour
{
    int sceneBuildIndex = 9;
    //[SerializeField] float keepHealth;              // Added LG
    public TestScriptableObject bookCount;
    public GameObject Player;
    public GameObject NeedPagesText;
    public float x, y;
    int playerPages;
    int currScene;

    void Start()
    {
        this.Player = GameObject.FindWithTag("Player");
        currScene = SceneManager.GetActiveScene().buildIndex;
        NeedPagesText.SetActive(false);
    }

    public void update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if (other.tag == "Player" && bookCount.currHealth >= 4)
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

            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        else
        {
            StartCoroutine(textBox());
        }
    }

    IEnumerator textBox()
    {
        NeedPagesText.SetActive(true);
        yield return new WaitForSeconds(5f);
        NeedPagesText.SetActive(false);
    }
}
