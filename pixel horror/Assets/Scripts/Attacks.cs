using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
  
    
    Vector2 rightAttackOffset;
    Collider2D batCollider;


    private void Start()
    {
        batCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }
   
    public void AttackRight()
    {
        batCollider.enabled = true;
        transform.position = rightAttackOffset;
    }
    public void AttackLeft()
    {
        batCollider.enabled = true;
        transform.position = new Vector3((rightAttackOffset.x * -1), rightAttackOffset.y);
    }
    private void StopAttack()
    {
        batCollider.enabled = false;
    }
}
