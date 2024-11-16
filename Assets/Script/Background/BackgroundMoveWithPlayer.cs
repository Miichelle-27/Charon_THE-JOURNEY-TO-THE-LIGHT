using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveWhitPlayer : MonoBehaviour
{
    [SerializeField] private Vector2 velocityMove;
    private Vector2 _offset;
    private Material _material;
    private Rigidbody2D _rb2DCharon;
    
   /* private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
   /* void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        if (_rb2D == null)
        {
            Debug.LogError($"{name} has not Rigidbody2D");
        } */
        
      /*  _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError($"{name} has not SpriteRenderer"); 
        }
    } */

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        _rb2DCharon = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _offset = (_rb2DCharon.velocity.x * 0.1f) * velocityMove * Time.deltaTime;
        _material.mainTextureOffset += _offset;
    }
}
