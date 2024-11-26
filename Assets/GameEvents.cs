using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this; 
    }

    public event Action onObstacleTriggerEnter;
    public void ObstacleTriggerEnter()
    {
        if(onObstacleTriggerEnter != null)
        {
            onObstacleTriggerEnter();
        }
    }

    public event Action onSpeedChange;
    public void SpeedChange()
    {
        if(onSpeedChange != null)
        {
            onSpeedChange();
        }
    }
}
