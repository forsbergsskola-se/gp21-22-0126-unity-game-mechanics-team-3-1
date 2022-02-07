using System.Collections;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private AnimationCurve scaleAnimationCurve = AnimationCurve.Linear(0, 0, 1, 1);

    public void PlayAnimation(float value)
    {
        StartCoroutine(AnimationCoroutine(value));
    }

    private IEnumerator AnimationCoroutine(float value)
    {
        var progress = 0f;

        while (progress < 1)
        {
            progress += Time.deltaTime / animationDuration;

            var scaleValue = scaleAnimationCurve.Evaluate(progress); //Get the value from our animation curve. the progress value maps to time on the curve (horizontal axis).
            scaleValue *= value; //Multiply by our value (in this case it is our jumpCharge) to scale the animation based on how high we jump.

            transform.localScale = new Vector3(
                1.5f + scaleValue,
                1.5f,
                1.5f + scaleValue);

            yield return null;
        }

        transform.localScale = new Vector3(1.5f,1.5f, 1.5f); //Just to be safe, make sure to reset the scale afterwards.
    }
}
