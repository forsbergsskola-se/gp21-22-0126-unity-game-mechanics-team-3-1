using UnityEngine;

public class EventCallbackExamples : MonoBehaviour
{
    private void Awake() => Debug.Log("Awake");

    private void Start() => Debug.Log("Start");

    private void OnEnable() => Debug.Log("OnEnable");

    private void OnDisable() => Debug.Log("OnDisable");

    private void OnDestroy() => Debug.Log("OnDestroy");

    private void OnApplicationQuit() => Debug.Log("OnApplicationQuit");

    private void Update() => Debug.Log("Update");

    private void LateUpdate() => Debug.Log("LateUpdate");

    private void FixedUpdate() => Debug.Log("FixedUpdate");
}