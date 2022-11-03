using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    #region "Variables"
    public float waitTime = 3;
    private PlayerController player;
    public bool isLava;
    #endregion

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        if(other.tag == "Player" )
        {
            if (!player.shield)
            {
               // Debug.Log("Calling Reset");
                callReset();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void callReset()
    {
       // Debug.Log("Calling ChangeScene");
        StartCoroutine(ResetCo());
    }

    IEnumerator ResetCo()
    {
       // Debug.Log("waiting 3 seconds");
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(3f);
        //Debug.Log("Calling ChangeScene");
        SceneManager.LoadScene("MenuScreen");

    }
}
