using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;

public class DomainExpansion : MonoBehaviour
{
    public Enemy enemyScript;

    [Header ("Dialogue")]
    [SerializeField] private GameObject TransformationDialogue;

    [Header ("Transformation Effects")]
    [SerializeField] private AudioSource bossMusic;
    [SerializeField] private GameObject panCamera;

    [Header ("Domain Map")]
    [SerializeField] private GameObject DomainA;
    [SerializeField] private GameObject DomainB;
    [SerializeField] private GameObject DomainC;
    [SerializeField] private GameObject DomainD;
    [SerializeField] private GameObject DomainE;
    [SerializeField] private GameObject DomainF;

    [Header ("Enemy Spawner")]
    public GameObject enemyPrefab;
    private float distance = 0.5f;
    float spawnTime = 25f;
    bool spawning = false;

    [Header ("Light Effect")]
    [SerializeField] private Light2D Light;

    bool DomainExpanded = false;

    private void HealthCheck()
    {
        if (enemyScript.CurrentHealth <= 90 && DomainExpanded == false)
        {
            DomainExpanded = true;
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
        spawning = true;
        bossMusic.Play();
    }

    IEnumerator WaitForMobs() 
    {
        enemyScript.enabled = false;
        yield return new WaitForSeconds(1f);
        enemyScript.enabled = true;
    }

    void SpawnMobs()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        if (spawning && (spawnTime <= 0)) 
        {
            StartCoroutine(WaitForMobs());
            Instantiate(enemyPrefab, new Vector2(transform.position.x + distance, transform.position.y), transform.rotation);
            Instantiate(enemyPrefab, new Vector2(transform.position.x + - distance, transform.position.y), transform.rotation);
            Instantiate(enemyPrefab, new Vector2(transform.position.x, transform.position.y + distance), transform.rotation);
            Instantiate(enemyPrefab, new Vector2(transform.position.x, transform.position.y - distance), transform.rotation);
            spawnTime = 25f;
        }
    }

    public void Update()
    {
        HealthCheck();
        
        SpawnMobs();
        
        Light.intensity = Mathf.PingPong(Time.time, 4f);

    }

}
