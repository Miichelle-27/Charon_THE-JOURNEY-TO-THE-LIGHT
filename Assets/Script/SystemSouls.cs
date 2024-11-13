using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SystemSouls : MonoBehaviour
{
    public int soulValue;
    public float speedFollow;
    private bool _isCollected;
    private Transform _player;
    
    private void Start()
    {
        soulValue = 1;
        speedFollow = 2f;
        _player = GameObject.FindWithTag("Player").transform; // Encuentra al personaje en la escena
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isCollected)
        {
            SoulsManager.instance.soulsCollected ++;
            _isCollected = true;
            GetComponent<Collider2D>().enabled = false; // Desactiva la colisión para evitar recolecciones adicionales
        }
    }
    
    void Update()
    {
        if (_isCollected && _player != null)
        {
            // Haz que el alma siga al jugador suavemente
            transform.position = Vector3.Lerp(transform.position, _player.position, Time.deltaTime * 5f);
        }
    }
}