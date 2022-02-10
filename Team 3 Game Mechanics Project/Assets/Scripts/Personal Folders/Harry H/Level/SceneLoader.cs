using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameObject Player;
    public string LevelToLoad;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerIdentifier>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        // null ref return checks
        if (other.gameObject != Player) return;
        
        LoadScene(LevelToLoad);
    }

    private static void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        Debug.Log($"{sceneName} loaded");
    }
    
    
}
