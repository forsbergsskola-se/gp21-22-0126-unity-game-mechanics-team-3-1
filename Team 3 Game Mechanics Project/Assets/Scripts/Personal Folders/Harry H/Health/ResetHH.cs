using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetHH : MonoBehaviour
{
    public float deathZone = -5f;
    public float respawnTime = 3f;
    private Vector3 startPos;
    public Vector3 spawnPos;
    private float spawnX;
    private int respawns;
    private int reset = 0;
    private bool onlyOnce;

    private void Awake()
    {
        onlyOnce = true;
        reset = PlayerPrefs.GetInt("Reset");
        respawns = PlayerPrefs.GetInt("Respawns");

        if (reset == 0)
        {
            startPos = transform.position;
            spawnPos = startPos;
            PlayerPrefs.SetInt("Respawns", 0);
            respawns = PlayerPrefs.GetInt("Respawns");
        }

        if (respawns == 0)
        {
            Debug.Log($"Respawns: {respawns}");
            startPos = transform.position;
            spawnPos = startPos;
        }
        
        else if (respawns > 0)
        {
            CheckNewSpawnLocation();
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            Restart();

        if (Input.GetKeyDown(KeyCode.Delete))
            ResetRespawns();
        
        if (transform.position.y >= deathZone) return;
        HandleReset();
    }

    private void CheckNewSpawnLocation()
    {
        Debug.Log($"Respawns: {respawns}");
        spawnX = PlayerPrefs.GetFloat("Player Spawn X");
        spawnPos = new Vector3(spawnX, spawnPos.y, spawnPos.z);
        transform.position = spawnPos;
    }
    
    private void HandleReset()
    {
        if (onlyOnce)
            StartCoroutine(Reset(spawnPos));
    }
    public IEnumerator Reset(Vector3 SpawnPosition)
    {
        onlyOnce = false;
        PlayerPrefs.SetInt("Reset", 1);
        spawnPos = SpawnPosition;
        respawns+=1;
        PlayerPrefs.SetFloat("Player Spawn X", spawnPos.x);
        PlayerPrefs.SetInt("Respawns", respawns);
        
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        respawns+=1;
        PlayerPrefs.SetInt("Respawns", respawns);
        PlayerPrefs.SetInt("Reset", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetRespawns()
    {
        PlayerPrefs.SetInt("Respawns", 0);
        respawns = 0; 
        Debug.Log("Reset successful");
    }
}