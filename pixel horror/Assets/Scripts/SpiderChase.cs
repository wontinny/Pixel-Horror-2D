using UnityEngine;

public class SpiderChase : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1f;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed = Time.deltaTime);
    }
}

