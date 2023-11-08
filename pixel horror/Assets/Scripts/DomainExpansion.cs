using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DomainExpansion : MonoBehaviour
{
    public Enemy enemyScript;

    [Header ("Dialogue")]
    [SerializeField] private GameObject TransformationDialogue;

    [Header ("Transformation Effects")]
    [SerializeField] private AudioSource domainSound;
    [SerializeField] private GameObject panCamera;

    [Header ("Domain Map")]
    [SerializeField] private GameObject DomainA;
    [SerializeField] private GameObject DomainB;
    [SerializeField] private GameObject DomainC;
    [SerializeField] private GameObject DomainD;
    [SerializeField] private GameObject DomainE;
    [SerializeField] private GameObject DomainF;

    bool DomainExpanded = false;
    private void HealthCheck()
    {
        if (enemyScript.CurrentHealth <= 90 && DomainExpanded == false)
        {
            DomainExpanded = true;
            domainSound.Play();
            StartCoroutine(TimeDelay());
        }
    }

    IEnumerator TimeDelay()
    {        
        enemyScript.enabled = false;
        yield return new WaitForSeconds(1f); // Delay to let the Player's knockback affect Mary
        gameObject.transform.position = new Vector2(0.15f, -0.25f); 
        panCamera.SetActive(true);
        TransformationDialogue.SetActive(true);
        yield return new WaitForSeconds(11);
        DomainA.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DomainB.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DomainC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DomainD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DomainE.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DomainF.SetActive(true);
        panCamera.SetActive(false);
        enemyScript.enabled = true;

    }

    public void Update()
    {
        HealthCheck();
    }
}
