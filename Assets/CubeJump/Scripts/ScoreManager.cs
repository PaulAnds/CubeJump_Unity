using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public float added;
    public Text scoreText;
    public bool keepadding;


    private void Start()
    {
        score = 0;
        keepadding = true;
    }

    private void Update()
    {
        if (keepadding)
        {
            if (score < 0)
            {
                score = 0;
            }
            added += Time.deltaTime;
            scoreText.text = "" + (score + (int)added);
            PlayerPrefs.SetInt("score", score + (int)added);
        }
    }

    public static void AddPoints(int _pointstoAdd)
    {
        score += _pointstoAdd;
    }
}