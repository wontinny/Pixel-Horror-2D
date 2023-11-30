using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    [field: SerializeField] private float knockbackForce = 50f;
    [field: SerializeField] private float playerKnockbackForce = 50f;
    //audio sources for player
    [SerializeField] private AudioSource dashAudio;
    [SerializeField] private AudioSource batHitAudio;
    [SerializeField] private AudioSource walkAudio;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    //how smooth the player moves (kinematic)
    public Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    //bool canMove = true;

    //variables for the dashing
    private float activeMoveSpeed;
    public float dashSpeed = 3f;
    public float dashLength = .2f;
    public float dashCooldown = 3f;
    private float dashCounter;
    private float dashCoolCounter;

    public float CurrentHealth;
    [field: SerializeField] public float MaxHealth = 100f;

    // GameOver script

    public GameOver GameOverScript;


    public HealthBar healthBar;                                             //added by Lukas

    public PlayerInput inputScript;

    public TestScriptableObject healthObject;

    public TestScriptableObject bookCount;
    public float startBookCount = 0;
    public float currentBooks;

    void Start()
    {   
        int y = SceneManager.GetActiveScene().buildIndex;
        if(y == 2)
        {
            healthObject.changeCurrHealth(100);
            bookCount.changeCurrHealth(0);

        }

        if (healthObject.currHealth <= 0)
                {
                    healthObject.changeCurrHealth(MaxHealth);
                }
        CurrentHealth = healthObject.currHealth;                // Changed from maxhealth to health object LG

        if (bookCount.currHealth > 0)
        {
            currentBooks = bookCount.currHealth;
            //set ui of book count to currentBooks
        }
        else
        {
            bookCount.changeCurrHealth(startBookCount);
        }
        
        float something = bookCount.currHealth;
        if(y == 6 && (something < 1f))
        {
            bookCount.changeCurrHealth(1f);
        }

        if (y == 2)
        {
            PlayerPrefs.SetFloat("PageM", 0f);
            PlayerPrefs.SetFloat("PageA", 0f);
            PlayerPrefs.SetFloat("PageR", 0f);
            PlayerPrefs.SetFloat("PageY", 0f);
            bookCount.changeCurrHealth(0);
        }
        
        if(y == 5)
        {
            PlayerPrefs.SetFloat("x", -0.97f);
            PlayerPrefs.SetFloat("y", 0.26f);
        }

        if(y == 6)
        {
            float lastx = PlayerPrefs.GetFloat("x");
            float lasty = PlayerPrefs.GetFloat("y");
            transform.position = (new Vector3(lastx, lasty, transform.position.z));
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        activeMoveSpeed = moveSpeed;

        healthBar.SetMaxHealth(MaxHealth);                                       //added by Lukas 
        healthBar.SetHealth(CurrentHealth);

        inputScript = GetComponent<PlayerInput>();

    }

    private void Update()
    {

        if (dashCounter > 0)
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
        }
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
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

        if (movementInput == Vector2.zero)
        {
            walkAudio.Play();
        }
        if (PauseMenu.GameIsPaused)
        {
            walkAudio.pitch *= 0;
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
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rightAttackPoint.transform.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                //Debug.Log("We hit right" + enemy.name);
                batHitAudio.Play();
                Vector2 direction = (enemy.transform.position - rightAttackPoint.position).normalized;
                Vector2 knockback = direction * knockbackForce;
                enemy.GetComponent<Enemy>().Damage(damageAmount, knockback);
            }
        }
        else
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(leftAttackPoint.transform.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                //Debug.Log("We hit left" + enemy.name);
                batHitAudio.Play();
                Vector2 direction = (enemy.transform.position - leftAttackPoint.position).normalized;
                Vector2 knockback = direction * knockbackForce;
                enemy.GetComponent<Enemy>().Damage(damageAmount, knockback);
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

    public void TakeDamage(float damageAmount, Vector2 knockback)
    {
        animator.SetBool("isMoving", false);
        animator.SetTrigger("damage");
        CurrentHealth -= damageAmount;
        StartCoroutine(StopInput());
        rb.AddForce(knockback, ForceMode2D.Impulse);

        healthObject.changeCurrHealth(CurrentHealth);
        healthBar.SetHealth(CurrentHealth);                                              //added by Lukas 


        if (CurrentHealth <= 0)
        {
            GameOverScript.Death();
            walkAudio.Stop();
            spriteRenderer.enabled = false;
        }
    }

    IEnumerator StopInput()
    {
        inputScript.enabled = false;
        yield return new WaitForSeconds(0.8f);
        inputScript.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "damagePlayer")
        {
            Vector2 direction = (transform.position - other.gameObject.transform.position).normalized;
            Vector2 knockback = direction * playerKnockbackForce;
            TakeDamage(10f, knockback);
        }
        if (other.gameObject.tag == "Item")
        {
            Heal(25);
            healthObject.changeCurrHealth(CurrentHealth);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "PageM")
        {
            currentBooks += 1;
            bookCount.changeCurrHealth(currentBooks);
            Destroy(other.gameObject);
            PlayerPrefs.SetFloat("PageM", 1f);
        }
        if (other.gameObject.tag == "PageA")
        {
            currentBooks += 1;
            bookCount.changeCurrHealth(currentBooks);
            Destroy(other.gameObject);
            PlayerPrefs.SetFloat("PageA", 1f);
        }
        if (other.gameObject.tag == "PageR")
        {
            currentBooks += 1;
            bookCount.changeCurrHealth(currentBooks);
            Destroy(other.gameObject);
            PlayerPrefs.SetFloat("PageR", 1f);
        }
        if (other.gameObject.tag == "PageY")
        {
            currentBooks += 1;
            bookCount.changeCurrHealth(currentBooks);
            Destroy(other.gameObject);
            PlayerPrefs.SetFloat("PageY", 1f);
        }
    }


    void OnDash()
    {

        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            dashAudio.Play();
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }



    /*public void LockMovement()
    {
        canMove = false;
    }

    public void UnLockMovement()
    {
        canMove = true;
    }*/

    public void Heal(float heal)
    {
        CurrentHealth += 25;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            healthBar.SetHealth(CurrentHealth);
        }
        else
        {
            healthBar.SetHealth(CurrentHealth);
        }
    }

}
