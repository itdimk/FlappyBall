using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    };

    const string AttemptsPrefsKey = "attempts count";
    public UnityEvent currentDifficultyChanged;
    public UnityEvent gameOver;

    public Difficulty initialDifficulty = Difficulty.Normal;
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

    public int AttemptsCount
    {
        get => PlayerPrefs.GetInt(AttemptsPrefsKey);
        set => PlayerPrefs.SetInt(AttemptsPrefsKey, value);
    }

    public float AttemptTime => Time.timeSinceLevelLoad;

    public void GameOver()
    {
        AttemptsCount++;
        gameOver.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        CurrentDifficulty = initialDifficulty;
    }


    // Update is called once per frame
    void Update()
    {
    }
}