using System.Collections;
using UnityEngine;

public class CameraShakeHH : MonoBehaviour
{
    private float elapsed;
    private Vector3 originalPos;

    public IEnumerator Shake(float duration, float magnitude)
    {
        elapsed = 0f;
        originalPos = transform.localPosition;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
