using System;
using TMPro;
using UnityEngine;

public class AttemptTimeUI : MonoBehaviour
{
    public TextMeshProUGUI writeTo;
    public string prefix;

    // Start is called before the first frame update
    void Start()
    {
        var gameManager = FindObjectOfType<GameManager>();
        if (!gameManager)
            Debug.LogError("Unable to find game manager");

        float fvalue = gameManager.AttemptTime;
        var timeSpan = new TimeSpan(0, 0, 0, 0, (int)(fvalue * 1000));
        writeTo.text = prefix + $"{timeSpan.Minutes:00}.{timeSpan.Seconds:00}.{timeSpan.Milliseconds / 10:00}";
    }
}