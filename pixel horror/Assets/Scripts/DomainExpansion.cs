using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomainExpansion : MonoBehaviour
{
    public Enemy enemyScript;
    [SerializeField] private AudioSource domainSound;

    bool DomainExpanded = false;
    private void HealthCheck()
    {
        if (enemyScript.CurrentHealth <= 90 && DomainExpanded == false)
        {
            DomainExpanded = true;
            domainSound.Play();
            gameObject.transform.position = new Vector2(0.15f, -0.25f); 
            Time.timeScale = 0f;
            StartCoroutine(TimeFreeze());
            Time.timeScale = 1f;
        }
    }

    IEnumerator TimeFreeze()
    {
        yield return new WaitForSeconds(2);
    }
    public void Update()
    {
        HealthCheck();
    }
}
