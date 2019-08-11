using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        Debug.Log("load next scene");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
    public void LoadCurrentSceneAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();      
    }

    public int GetCurrenSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadClearMenu()
    {
        SceneManager.LoadScene("ClearMenu");
    }
}
