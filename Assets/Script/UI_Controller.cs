using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    //public static UI_Controller instance;
    
    // Referencia al texto de la UI
    public Text soulsText;
    
    private int _soulsCollected;
    private int _soulsToCollect;
    
    //public Text soulsText;
    
    // Start is called before the first frame update

    void Start()
    {
        UpdateUIText();
        //UpdateSoulCount();
    }
    
    // Función para actualizar el texto de la UI
    private void UpdateUIText()
    {
        soulsText.text = ($"{_soulsCollected} / {_soulsToCollect}");
    }

   /* public void UpdateSoulCount()
    {
        soulsText.text = GameManager.instance.soulsCollected.ToString();
    }*/
}
