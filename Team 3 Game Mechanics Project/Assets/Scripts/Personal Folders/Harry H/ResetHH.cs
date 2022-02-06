using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetHH : MonoBehaviour
{
    public float deathZone = -5f;
    public float respawnTime = 3f;
    void Update()
    {
        HandleReset();
    }

    private void HandleReset()
    {
        if (transform.position.y <= deathZone)
        {
            StartCoroutine(Reset());
        }
    }
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}