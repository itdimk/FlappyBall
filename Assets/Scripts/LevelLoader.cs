using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Loads scenes by scene name or by build index
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