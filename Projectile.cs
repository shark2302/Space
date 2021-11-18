using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Speed = 10;
    
    public int Damage = 1;
    
    public Vector3 Direction = Vector3.up;
    
    private Rigidbody _rigidbody;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Direction * Speed; 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Health -= Damage;
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<Hero>(out var hero))
        {
            hero.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}
