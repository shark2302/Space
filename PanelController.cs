using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{

    public Text LastScore;

    public Text HighScore;
    
    
    private void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore");
        LastScore.text = "Последний результат:" + 
                         lastScore.ToString();
        if (lastScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", lastScore);
        }

        HighScore.text = "Лучший результат: " + 
                         PlayerPrefs.GetInt("HighScore").ToString();
    }
   //using UnityEngine.UI; 
//using UnityEngine.SceneManagement;
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
