using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentTime;
    private bool isRunning;
    public TextMeshProUGUI textMesh;
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) {
            
            currentTime += Time.deltaTime;
        }
        DisplayTime();
    }

    public void StartTimer() { 
        isRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = 0;
    }
    public void StopTimer() {
        isRunning = false;
    }

    public void DisplayTime() {
        var minutes = Mathf.Floor(currentTime / 60);
        var seconds = Mathf.Floor(currentTime % 60);
        textMesh.text = minutes + ":" + seconds;
    }
}
