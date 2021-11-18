using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    public bool KeepOnScreen;
    public float Radius = 1;

   
    private float _cameraWidth;
    private float _cameraHeight;
    
    public bool IsOnScreen { get; private set; }
    private void Awake()
    {
        _cameraHeight = Camera.main.orthographicSize;
        //отношение ширины к высоте с поля зрения камеры
        _cameraWidth = _cameraHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        IsOnScreen = true;
        Vector3 position = transform.position;
        if (position.x > _cameraWidth - Radius)
        {
            position.x = _cameraWidth - Radius;
            IsOnScreen = false;
        }
        if (position.x < -_cameraWidth + Radius)
        {
            position.x = -_cameraWidth + Radius;
            IsOnScreen = false;
        }
        if (position.y > _cameraHeight - Radius)
        {
            position.y = _cameraHeight - Radius;
            IsOnScreen = false;
        }
        if (position.y < -_cameraHeight + Radius)
        {
            position.y = -_cameraHeight + Radius;
            IsOnScreen = false;
        }

        if (KeepOnScreen && !IsOnScreen)
        {
            transform.position = position;
            IsOnScreen = true;
        }
        else if(!IsOnScreen)
        {
            Destroy(gameObject);
        }
        transform.position = position;
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        Vector3 boundSize = new Vector3(_cameraWidth * 2, 
            _cameraHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
    
    
    
    
    
    
    
    
}
