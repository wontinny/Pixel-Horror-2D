using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DomainExpansion : MonoBehaviour
{
    public Enemy enemyScript;
    [SerializeField] private AudioSource domainSound;
    [SerializeField] private GameObject panCamera;

    bool DomainExpanded = false;
    private void HealthCheck()
    {
        if (enemyScript.CurrentHealth <= 90 && DomainExpanded == false)
        {
            DomainExpanded = true;
            domainSound.Play();
            gameObject.transform.position = new Vector2(0.15f, -0.25f); 
            StartCoroutine(TimeDelay());
        }
    }

    IEnumerator TimeDelay()
    {
        panCamera.SetActive(true);
        yield return new WaitForSeconds(5);
        panCamera.SetActive(false);
    }
    public void Update()
    {
        HealthCheck();
    }
}
