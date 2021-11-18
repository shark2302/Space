using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static Restart solo;

    private void Awake()
    {
        if (solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("Restart has been already created!!!");
        }
    }
//using UnityEngine.SceneManagement;
    public void DelayedRestart(float delay)
    {
        Invoke("RestartGame", delay);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
