using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;

    public Attacks BatAttack;
    public Transform rightAttackPoint;
    public Transform leftAttackPoint;
    public float attackRange = 0.1f;
    public LayerMask enemyLayers;
    [field: SerializeField] private float damageAmount = 50f;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    //how smooth the player moves (kinematic)
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    //bool canMove = true;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        activeMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }*/
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (movementInput.x < 0)
        {
            
            spriteRenderer.flipX = true;
        
        }
        else if (movementInput.x > 0)
        {
            
            spriteRenderer.flipX = false;
           
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                activeMoveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * activeMoveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    
    void OnFire()
    {
        animator.SetTrigger("batAttack");
        if (spriteRenderer.flipX != true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rightAttackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit right" + enemy.name);
                enemy.GetComponent<Enemy>().Damage(damageAmount);
            }
        }
        else
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(leftAttackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit left" + enemy.name);
                enemy.GetComponent<Enemy>().Damage(damageAmount);
            }
        }
    }
    
    public void batAttack()
    {
        if (spriteRenderer.flipX != true)
        {
            BatAttack.AttackLeft();
        }
        else
        {
            BatAttack.AttackRight();
        }
    }

    public void stopAttack()
    {
        BatAttack.StopAttack();
    }
    
    
   /* void OnDash()
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }*/



    /*public void LockMovement()
    {
        canMove = false;
    }

    public void UnLockMovement()
    {
        canMove = true;
    }*/
}
