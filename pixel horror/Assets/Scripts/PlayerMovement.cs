using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    void Update() // Input
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // -1 Left, 1 Right
        movement.y = Input.GetAxisRaw("Vertical"); // 1 Up, -1 Down
    }

    private void FixedUpdate() // Movement
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
