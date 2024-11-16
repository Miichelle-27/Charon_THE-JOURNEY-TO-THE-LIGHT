using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsManager : MonoBehaviour
{
    public static SoulsManager instance;
        
    public Text soulsText; // Referencia al texto de la UI
    public int soulsCollected; // Contador de almas recolectadas
    public int totalSouls;

    private void Start()
    { 
        totalSouls = 7;
        UpdateSoulCount();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void UpdateSoulCount()
    {
        soulsText.text = ($"{soulsCollected} / {totalSouls}");
    }
}