using UnityEngine;

public class SpiderChase : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1f;
    private float chaseDistance = 1f;
    private bool isChasing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            // Spider has touched the player, so stop chasing.
            isChasing = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance <= chaseDistance)
        {
            // Spider is within chase range, so it should chase the player.
            isChasing = true;
        }
        else
        {
            // Spider is outside of chase range, so it should stop chasing.
            isChasing = false;
        }

        if (isChasing)
        {
            // Calculate the direction towards the player.
            Vector2 direction = Player.transform.position - transform.position;

            // Move the spider towards the player.
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }
}