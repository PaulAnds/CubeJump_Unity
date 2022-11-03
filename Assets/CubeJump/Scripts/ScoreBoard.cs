using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    #region "Variables"
    public Text HighScore;
    public Text score1;
    public Text score2;
    public Text score3;

    private int high;
    private int intScore1;
    private int intScore2;
    private int intScore3;
    private int placement;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        high = PlayerPrefs.GetInt("HighScore");
        intScore1 = PlayerPrefs.GetInt("score1");
        intScore2 = PlayerPrefs.GetInt("score2");
        intScore3 = PlayerPrefs.GetInt("score3");
        placement = PlayerPrefs.GetInt("score");

        if(high < placement)
        {
            PlayerPrefs.SetInt("HighScore", placement);


            PlayerPrefs.SetInt("score1", high);
            PlayerPrefs.SetInt("score2", intScore1);
            PlayerPrefs.SetInt("score3", intScore2);
        }
        else if (intScore1 < placement)
        {
            PlayerPrefs.SetInt("score1", placement);


            PlayerPrefs.SetInt("score2", intScore1);
            PlayerPrefs.SetInt("score3", intScore2);
        }
        else if (intScore2 < placement)
        {
            PlayerPrefs.SetInt("score2", placement);

            PlayerPrefs.SetInt("score3", intScore2);
        }
        else if (intScore3 < placement)
        {
            PlayerPrefs.SetInt("score3", placement);
        }
        HighScore.text = "" + PlayerPrefs.GetInt("HighScore");
        score1.text = "" + PlayerPrefs.GetInt("score1");
        score2.text = "" + PlayerPrefs.GetInt("score2");
        score3.text = "" + PlayerPrefs.GetInt("score3"); 

    }

}
