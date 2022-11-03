using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Text countdown;
    public bool timer;
    public float time;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        timer = true;
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            if(time > 0)
            {
                Time.timeScale = 0.01f;
                time -= (Time.deltaTime * 100);
                countdown.text = "" + (int)time;
            }
            else
            {
                time = 0;
                timer = false;
                Time.timeScale = 1f;
                ui.SetActive(false);
            }
        }
    }
}
