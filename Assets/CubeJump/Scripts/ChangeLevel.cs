using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void LevelChanger(string _levelToLoad)
    {
        SceneManager.LoadScene(_levelToLoad);
        Debug.Log("changing scene");
    }
    public void exitgame()
    {
        Application.Quit();
        Debug.Log("exiting");
    }

}
