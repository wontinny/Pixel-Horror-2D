using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;

public class DomainExpansion : MonoBehaviour
{
    public Enemy enemyScript;

    [Header ("Boss Health Bar")]
    public HealthBar bossBar;
    public GameObject bossBarUI;

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
    [SerializeField] private AudioSource spawnSound;
    public GameObject enemyPrefab;
    public GameObject ghostPrefab;
    private float distance = 0.5f;
    float spawnTime = 25f;
    bool spawning = false;

    [Header ("Light Effect")]
    [SerializeField] private Light2D Light;

    [Header("Stop Player")]
    public GameObject Player;
    public PlayerInput inputScript;
    public ExtraAttack ExtraAttackScript;

    bool DomainExpanded = false;

    private void HealthCheck()
    {
        if (enemyScript.CurrentHealth <= 100 && DomainExpanded == false)
        {
            enemyScript.enabled = false;
            DomainExpanded = true;
            StartCoroutine(TimeDelay());
            StartCoroutine(StopInput());
        }
    }

    IEnumerator StopInput()
    {   
        inputScript.enabled = false;
        yield return new WaitForSeconds(15.5f);
        inputScript.enabled = true;
    }

    IEnumerator TimeDelay()
    {               
        bossBarUI.SetActive(false);
        enemyScript.CurrentHealth = 50000;
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
        yield return new WaitForSeconds(2f);
        enemyScript.CurrentHealth = 100;
        bossBarUI.SetActive(true);
        while (enemyScript.CurrentHealth < enemyScript.MaxHealth)
        {
            yield return new WaitForSeconds(0.01f);
            enemyScript.CurrentHealth += 2;
        }
    }

    IEnumerator WaitForMobs() 
    {
        enemyScript.enabled = false;
        yield return new WaitForSeconds(1f);
        enemyScript.enabled = true;
        ExtraAttackScript.enabled = true;
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
            spawnSound.Play();
            Instantiate(enemyPrefab, new Vector2(transform.position.x + distance, transform.position.y), transform.rotation);
            Instantiate(enemyPrefab, new Vector2(transform.position.x + - distance, transform.position.y), transform.rotation);
            Instantiate(enemyPrefab, new Vector2(transform.position.x, transform.position.y + distance), transform.rotation);
            Instantiate(enemyPrefab, new Vector2(transform.position.x, transform.position.y - distance), transform.rotation);
            spawnTime = 25f;
        }
    }

    public void Start()
    {
        bossBar.SetMaxHealth(enemyScript.CurrentHealth);
        this.Player = GameObject.FindWithTag("Player");
        inputScript = Player.GetComponent<PlayerInput>();
        ExtraAttackScript = GetComponent<ExtraAttack>();
        ExtraAttackScript.enabled = false;
    }

    public void Update()
    {
        bossBar.SetHealth(enemyScript.CurrentHealth);

        HealthCheck();
        
        SpawnMobs();
        
        if (DomainExpanded)
        {
            Light.intensity = Mathf.PingPong(Time.time, 4f);
        }

    }

}
