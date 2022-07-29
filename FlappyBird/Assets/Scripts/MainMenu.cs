using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Text bestScore;
    public Text Score;
     void Start()
    {
        int besstScore = PlayerPrefs.GetInt("log");
        int ScoreCame = PlayerPrefs.GetInt("log2");
        bestScore.text ="BEST SCORE>"+besstScore;
        Score.text = "Puan->" + ScoreCame;
    }
    public void gotoGame() {
        SceneManager.LoadScene("Level1");
    
    }

    public void leavetheGame() {
        Application.Quit();
    }
}
