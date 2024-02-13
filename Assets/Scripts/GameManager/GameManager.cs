using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }
  
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

}
