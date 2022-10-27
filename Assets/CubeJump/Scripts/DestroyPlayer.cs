using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    #region "Variables"
    public float waitTime = 3;
    private GameObject pausebutton;
    private PlayerController player;
    public bool isLava;
    #endregion

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        pausebutton = GameObject.Find("PauseButton");
    }

    private void Update()
    {
        if (player.powerJump && !isLava)
        {
            Destroy(gameObject);
        }
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
