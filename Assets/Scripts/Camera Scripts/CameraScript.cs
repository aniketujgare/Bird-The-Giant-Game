﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private float speed = 1f, acceleration = 0.2f, maxSpeed = 3.2f;
    private float easySpeed = 1.9f, mediumSpeed = 3.5f, hardSpeed = 4.2f;

    [HideInInspector] public bool moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            maxSpeed = easySpeed;
        }
        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            maxSpeed = mediumSpeed;
        }
        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            maxSpeed = hardSpeed;
        }
        moveCamera = true;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }
    void MoveCamera()
    {
        Vector3 temp = transform.position;
            
            float oldY = temp.y;
            float newY = temp.y - (speed * Time.deltaTime);

            temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;

        speed += acceleration * Time.deltaTime;
        if (speed>maxSpeed)
        {
            speed = maxSpeed;
        }
    }


}
