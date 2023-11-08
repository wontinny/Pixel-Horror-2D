using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomainExpansion : MonoBehaviour
{
    public Enemy enemyScript;

    private void HealthCheck()
    {
        if (enemyScript.CurrentHealth < 50)
        {
            Destroy(gameObject);
        }
    }
}
