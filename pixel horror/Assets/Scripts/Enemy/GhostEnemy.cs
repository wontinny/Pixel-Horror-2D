using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public float speed = 1f;
    public float TimeTillDeath = 10f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canDash = true;
        Object.Destroy(gameObject, TimeTillDeath);
    }

    private bool canDash;
    private bool isDashing;

    void Update()
    {
        if (canDash)
        {
            StartCoroutine(DashMovementHandler());
            if (isDashing)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed * 2.5f);
            }
        }
    }

    IEnumerator DashMovementHandler()
    {
        canDash = true;
        yield return new WaitForSeconds(1f);

        isDashing = true;
        yield return new WaitForSeconds(1f);

        canDash = false;
        isDashing = false;
        yield return new WaitForSeconds(1f);

        canDash = true;
    }
}
