using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public static Hero solo;

    public float Speed = 30;

    [Tooltip("Вращение при движении вправо")]
    public float RollMult = -45;

    public float PitchMult = 30;

    public int Health = 4;

    public GameObject ProjectTilePrefab;

    public KeyCode ShootKey = KeyCode.Space;

    public Text Score;
    

    [Header("Set dynamically")]
    public float ShieldLevel = 4;

    private GameObject _lastTrigger;
    private int _score;

    private void Awake()
    {
        if (solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("Hero has already created!");
        }
    }
    
    
    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(xAxis, yAxis, 0) * Speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(yAxis * PitchMult, xAxis * RollMult, 0);

        if (Input.GetKeyDown(ShootKey))
        {
            Fire();
        }
        
        if (Health <= 0)
        {
            SaveResults();
            Restart.solo.DelayedRestart(2);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootHere = other.gameObject.transform.root;
        GameObject go = rootHere.gameObject;
        Debug.Log("Collision detected with " + go.name);

        if (go == _lastTrigger)
        {
            return;
        }

        _lastTrigger = go;

        if (go.GetComponent<Enemy>() != null)
        {
            GetDamage(1);
            Destroy(go);
        }

    }

    public void GetDamage(int damage)
    {
        if (ShieldLevel > 0)
        {
            ShieldLevel -= 1;
        }
        else
        {
            Health -= damage;
        }
    }


    private void Fire()
    {
        Instantiate(ProjectTilePrefab,
            transform.position, Quaternion.identity);
    }

    public void AddScore(int value)
    {
        _score += value;
        
        Score.text = "Score: " + _score.ToString();
    }

    private void SaveResults()
    {
        PlayerPrefs.SetInt("LastScore", _score);
    }
    
}
