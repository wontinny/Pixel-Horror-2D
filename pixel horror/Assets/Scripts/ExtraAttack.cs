using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAttack : MonoBehaviour
{
    public Rigidbody2D BloodShot;
    public Rigidbody2D Heart;
    public GameObject Player;
    public GameObject Mary;
    public Enemy enemyScript;

    public float _timer;
    private float _timeBetweeenShots = .5f;
    float _bulletSpeed = 5f;
    public float _heartSpeed = 1.75f;

    Vector2 top;
    Vector2 right;
    Vector2 bottom;
    Vector2 left;

    int AttackLimit;

    bool takeBreak = false;

    int pos = 1;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Mary = GameObject.FindWithTag("Mary");
        AttackLimit = 0;
    }

    public void Update()
    {
        if (_timer > _timeBetweeenShots && !takeBreak)
        {
            _timer = 0f;
            int randomAttack = Random.Range(5, 10);
            //calculations for top, left, bottom, right
            if(pos == 1)
            {
                top = new Vector2(Mary.transform.position.x, Mary.transform.position.y + 2);
                right = new Vector2(Mary.transform.position.x + 2, Mary.transform.position.y);
                bottom = new Vector2(Mary.transform.position.x, Mary.transform.position.y - 2);
                left = new Vector2(Mary.transform.position.x - 2, Mary.transform.position.y);
                pos = 0;
            }
            else
            {
                top = new Vector2(Mary.transform.position.x + 2, Mary.transform.position.y + 2);
                right = new Vector2(Mary.transform.position.x + 2, Mary.transform.position.y - 2);
                bottom = new Vector2(Mary.transform.position.x - 2, Mary.transform.position.y - 2);
                left = new Vector2(Mary.transform.position.x - 2, Mary.transform.position.y + 2);
                pos = 1;
            }
            

            top = (top - (Vector2)Mary.transform.position).normalized;
            right = (right - (Vector2)Mary.transform.position).normalized;
            bottom = (bottom - (Vector2)Mary.transform.position).normalized;
            left = (left - (Vector2)Mary.transform.position).normalized;

            int type = Random.Range(1, 8);
            print(type);
            if(type == 1)
            {
                //top
                Rigidbody2D topRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                topRB.velocity = top * _bulletSpeed;
                //right
                Rigidbody2D rightRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                rightRB.velocity = right * _bulletSpeed;
                //bottom
                Rigidbody2D bottomRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                bottomRB.velocity = bottom * _bulletSpeed;
                //left
                Rigidbody2D leftRB = Instantiate(Heart, Mary.transform.position, Quaternion.identity);
                leftRB.velocity = left * _heartSpeed;
            }
            else if(type == 2)
            {
                //top
                Rigidbody2D topRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                topRB.velocity = top * _bulletSpeed;
                //right
                Rigidbody2D rightRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                rightRB.velocity = right * _bulletSpeed;
                //bottom
                Rigidbody2D bottomRB = Instantiate(Heart, Mary.transform.position, Quaternion.identity);
                bottomRB.velocity = bottom * _heartSpeed;
                //left
                Rigidbody2D leftRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                leftRB.velocity = left * _bulletSpeed;
            }
            else if(type == 3)
            {
                //top
                Rigidbody2D topRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                topRB.velocity = top * _bulletSpeed;
                //right
                Rigidbody2D rightRB = Instantiate(Heart, Mary.transform.position, Quaternion.identity);
                rightRB.velocity = right * _heartSpeed;
                //bottom
                Rigidbody2D bottomRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                bottomRB.velocity = bottom * _bulletSpeed;
                //left
                Rigidbody2D leftRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                leftRB.velocity = left * _bulletSpeed;
            }
            else if(type == 4)
            {
                //top
                Rigidbody2D topRB = Instantiate(Heart, Mary.transform.position, Quaternion.identity);
                topRB.velocity = top * _heartSpeed;
                //right
                Rigidbody2D rightRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                rightRB.velocity = right * _bulletSpeed;
                //bottom
                Rigidbody2D bottomRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                bottomRB.velocity = bottom * _bulletSpeed;
                //left
                Rigidbody2D leftRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                leftRB.velocity = left * _bulletSpeed;
            }
            else
            {
                //top
                Rigidbody2D topRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                topRB.velocity = top * _bulletSpeed;
                //right
                Rigidbody2D rightRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                rightRB.velocity = right * _bulletSpeed;
                //bottom
                Rigidbody2D bottomRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                bottomRB.velocity = bottom * _bulletSpeed;
                //left
                Rigidbody2D leftRB = Instantiate(BloodShot, Mary.transform.position, Quaternion.identity);
                leftRB.velocity = left * _bulletSpeed;
            }
            AttackLimit += 1;
            if(AttackLimit >= randomAttack)
            {
                StartCoroutine(TakeBreak());
                AttackLimit = 0;
            }
        }

        _timer += Time.deltaTime;
    }

    IEnumerator TakeBreak()
    {
        takeBreak = true;
        yield return new WaitForSeconds(4f);
        takeBreak = false;
    }
}
