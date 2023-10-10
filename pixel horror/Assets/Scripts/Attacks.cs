using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public Collider2D batCollider;

    Vector2 rightAttackOffset;

    


    private void Start()
    {
        rightAttackOffset = transform.position;
    }
   
    public void AttackRight()
    {
        batCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        batCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAttack()
    {
        batCollider.enabled = false;
    }
}
