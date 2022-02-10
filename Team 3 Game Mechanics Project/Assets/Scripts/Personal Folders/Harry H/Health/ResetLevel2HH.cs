using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel2HH : MonoBehaviour
{
    public float deathZone = -5f;
    public float respawnTime = 3f;
    private Vector3 startPos2;
    public Vector3 spawnPos2;
    private float spawnX2;
    private int respawns2;
    private int reset2 = 0;
    private bool onlyOnce;

    private void Awake()
    {
        onlyOnce = true;
        reset2 = PlayerPrefs.GetInt("Reset");
        respawns2 = PlayerPrefs.GetInt("Respawns2");

        if (reset2 == 0)
        {
            startPos2 = transform.position;
            spawnPos2 = startPos2;
            PlayerPrefs.SetInt("Respawns2", 0);
            respawns2 = PlayerPrefs.GetInt("Respawns2");
        }

        if (respawns2 == 0)
        {
            Debug.Log($"Respawns: {respawns2}");
            startPos2 = transform.position;
            spawnPos2 = startPos2;
        }
        
        else if (respawns2 > 0)
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
        Debug.Log($"Respawns: {respawns2}");
        spawnX2 = PlayerPrefs.GetFloat("Player Spawn X2");
        spawnPos2 = new Vector3(spawnX2, spawnPos2.y, spawnPos2.z);
        transform.position = spawnPos2;
    }
    
    private void HandleReset()
    {
        if (onlyOnce)
            StartCoroutine(Reset(spawnPos2));
    }
    public IEnumerator Reset(Vector3 SpawnPosition)
    {
        onlyOnce = false;
        PlayerPrefs.SetInt("Reset2", 1);
        spawnPos2 = SpawnPosition;
        respawns2+=1;
        PlayerPrefs.SetFloat("Player Spawn X2", spawnPos2.x);
        PlayerPrefs.SetInt("Respawns2", respawns2);
        
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        respawns2+=1;
        PlayerPrefs.SetInt("Respawns2", respawns2);
        PlayerPrefs.SetInt("Reset2", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetRespawns()
    {
        PlayerPrefs.SetInt("Respawns2", 0);
        respawns2 = 0; 
        Debug.Log("Reset successful");
    }
}