using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class Timer : MonoBehaviour
{
    public Text timerText;
    public int startingSeconds;

    private float elapsedTime;

    // Use this for initialization
    void Start()
    {
        elapsedTime = 0.0f;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int timeInSeconds = (int)(elapsedTime % 60);
        int minutes = 0;
        int remainingSeconds = startingSeconds - timeInSeconds;
        if (startingSeconds >= 60)
        {
            minutes = (int)((startingSeconds - timeInSeconds) / 60);
            remainingSeconds -= (minutes * 60);
        }
        timerText.text = minutes.ToString() + ":" + remainingSeconds.ToString().PadLeft(2, '0');
    }
}