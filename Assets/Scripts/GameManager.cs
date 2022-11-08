using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Отвечает за общие игровые параметры: состояние игры, ее сложность
public class GameManager : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    };

    private Difficulty _currentDifficulty;

    public Difficulty CurrentDifficulty
    {
        get => _currentDifficulty;
        set
        {
            _currentDifficulty = value;
            currentDifficultyChanged.Invoke();
        }
    }

    public UnityEvent currentDifficultyChanged;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
    }
}