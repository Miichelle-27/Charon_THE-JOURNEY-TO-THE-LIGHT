using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Advertisements;
using UnityEngine;

public class SystemLevelUp : MonoBehaviour
{
    
    public int level; // Nivel inicial del jugador
    private int _currentSouls; // Cantidad actual de almas del jugador
    private int _totalSoul;
    
    void Start()
    {
        level = 1;
        _currentSouls = 0;
        _totalSoul = 7;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CollectionSouls(1);
        }
        if (_currentSouls >= _totalSoul)
        {
            LevelUp();
        }
        
        void CollectionSouls(int collectorSoul = 7)
        {
            for (int i = 0; i < collectorSoul ; i++)
            {
                _currentSouls ++;
                Debug.Log($"Souls collection currently {_currentSouls}/7");
            }
        }
        
        void LevelUp()
        {
            level++;
            _currentSouls = 0;
            Debug.Log($"Congratulations! You have succeeded! You can go to next level! Current level: {level}");
        }
    }
    
}