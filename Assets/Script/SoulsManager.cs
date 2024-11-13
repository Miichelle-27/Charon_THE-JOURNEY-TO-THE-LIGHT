using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsManager : MonoBehaviour
{
    public static SoulsManager instance;
    
  //  public Text soulCountUI; // Referencia al componente de texto en la UI
    
  //  private int _totalSouls; 
    public int soulsCollected; // Contador de almas recolectadas

    private void Start()
    {
     //   _totalSouls = 7;
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

  /*  public void AddSoul()
    {
        soulsCollected ++; // Aumenta el contador
        soulCountUI.text = ($"{soulsCollected} / {_totalSouls}"); // Actualiza el texto en la UI
    }*/
}