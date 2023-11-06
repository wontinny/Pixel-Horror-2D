using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private const float MOVE_SPEED = 1f;
    [SerializeField] private LayerMask dashLayerMask;
    Rigidbody2D rb;
    private Vector3 moveDir;
    private bool isDash;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        moveDir = new Vector3(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isDash = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDir * MOVE_SPEED;

        if (isDash)
        {
            float dashAmount = 1f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }
            rb.MovePosition(dashPosition);
            isDash = false;
        }
    }
}
