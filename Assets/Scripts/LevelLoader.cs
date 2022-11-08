using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Загружает сцену по индексу или имени
public class LevelLoader : MonoBehaviour
{
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Load(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}