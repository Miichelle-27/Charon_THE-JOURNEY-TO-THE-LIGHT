using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Charon : MonoBehaviour
{
    public float velocity = 2;
    public float jumpForce = 5;
    public float radioSphere;
    public Vector2 positionSphere;
    private Collider2D _inGround;
    private float _direction;
    
    private Animator _animator;
    private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError($"{name} has not Animator");
        }
        
        _rb2D = GetComponent<Rigidbody2D>();
        if (_rb2D == null)
        {
            Debug.LogError($"{name} has not Rigidbody2D");
        }
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError($"{name} has not SpriteRenderer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _inGround = Physics2D.OverlapCircle(new Vector2(transform.position.x + positionSphere.x, transform.position.y + positionSphere.y), radioSphere, 1<<3);
        
        //  Idle & Walking Animation
        if (_direction == 0)  //  If it's still
        {
            //  Play the idle animation
            _animator.SetBool("walk", false);
        }
        else
        {
            //  Play the walk animation
            _animator.SetBool("walk",true);
        }
        
            //  Jumping and Falling Animation
        _animator.SetFloat("velocityY",_rb2D.velocity.y);

        _animator.SetBool("inGround", _inGround);  //  It's touching the ground
        
        // Flip player  
        if (_direction > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (_direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        // Control & Motion
        _direction = Input.GetAxis("Horizontal");
        _rb2D.velocity = new Vector2(velocity * _direction, _rb2D.velocity.y);
        
            //  Jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (_inGround == true)
            {
                _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpForce);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + positionSphere.x, transform.position.y + positionSphere.y), radioSphere);
    }
}
