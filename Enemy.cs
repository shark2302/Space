using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;

    public float FireRate = 0.4f;

    public float Health = 10;

    [Tooltip("Очки, получаемые игроком за уничтожение данного врага")]
    public float Score = 100;

    public GameObject ProjectilePrefab;

    private BoundsChecker _boundsChecker;

    private float _nextFire;
    
    public Vector3 Position
    {
        get { return this.transform.position; }
        set { transform.position = value; }
    }

    private void Awake()
    {
        _boundsChecker = GetComponent<BoundsChecker>();
    }

    private void Start()
    {
        _nextFire = FireRate;
    }

    private void Move()
    {
        Position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        
        if (_nextFire > 0)
        {
            _nextFire -= Time.deltaTime;
        }
        else
        {
            Fire();
            _nextFire = FireRate;
        }
        
        if (Health <= 0)
        {
            Hero.solo.AddScore((int) Score);
            Destroy(gameObject);
        }
    }

    public void Fire()
    {
        Instantiate(ProjectilePrefab,
            transform.position, Quaternion.identity);
    }
    
    
    
}
