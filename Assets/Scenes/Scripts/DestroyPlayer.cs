using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{

    public float waitTime = 3;
    public GameObject pausebutton;

    private void Start()
    {
        pausebutton = GameObject.Find("PauseButton");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            callReset();
        }
    }

    public void callReset()
    {
        pausebutton.SetActive(false);
        Invoke("ResetGame", waitTime);
    }
    public void ResetGame()
    {
        // Restarts the current level 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
