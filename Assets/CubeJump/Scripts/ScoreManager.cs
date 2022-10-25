using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public float added;
    public Text scoreText;


    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        added += Time.deltaTime;
        scoreText.text = "" + (score + (int)added);
    }

    public static void AddPoints(int _pointstoAdd)
    {
        score += _pointstoAdd;
    }
}