using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttemptCountUI : MonoBehaviour
{
    public TextMeshProUGUI writeTo;
    public string prefix;
    
    void Start()
    {
        var gameManager = FindObjectOfType<GameManager>();
        if (!gameManager)
            Debug.LogError("Unable to find game manager");
        writeTo.text = prefix + gameManager.AttemptsCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
