using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;

    System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    public void ResetTimer() {
        stopWatch.Reset();
    }

    public void StartTimer() {
        ResetTimer();
        stopWatch.Start();
    }

    public void StopTimer() {
        stopWatch.Stop();
    }

    // Get seconds passed
    public int GetCurrentTime() {
        return (int)(stopWatch.ElapsedMilliseconds / 1000f);
    }

    private void FixedUpdate()
    {
        int currentTime = GetCurrentTime();
        timerText.text = currentTime.ToString();
    }
}
