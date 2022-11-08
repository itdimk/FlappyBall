using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficultyButton : MonoBehaviour
{
    public Button targetButton;
    public GameManager.Difficulty buttonDifficulty;
    private GameManager _manager;


    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<GameManager>();
        if (!_manager)
            Debug.LogError("Unable to find GameManager on the scene");

        targetButton.onClick.AddListener(ButtonOnClick);
        _manager.currentDifficultyChanged.AddListener(ManagerOnDifficultyChanged);
        ManagerOnDifficultyChanged();
    }

    private void ManagerOnDifficultyChanged()
    {
        targetButton.interactable = _manager.CurrentDifficulty != buttonDifficulty;
    }

    private void ButtonOnClick()
    {
        if (_manager.CurrentDifficulty != buttonDifficulty)
            _manager.CurrentDifficulty = buttonDifficulty;
    }

    // Update is called once per frame
    void Update()
    {
    }
}