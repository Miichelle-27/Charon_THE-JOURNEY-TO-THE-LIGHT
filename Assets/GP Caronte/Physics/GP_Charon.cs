using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Charon : MonoBehaviour
{
    public float velocity = 2;
    public float jump;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            GetComponent<Animator>().SetBool("walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk",true);
        }
        
        GetComponent<Animator>().SetFloat("velocityY",GetComponent<Rigidbody2D>().velocity.y);  // Jump

        if (GetComponent<Rigidbody2D>().velocity.y == 0)  // Falling down
        {
            GetComponent<Animator>().SetTrigger("inFloor");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow)) //  Walk right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))  // Walk left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        
        if (Input.GetKey(KeyCode.Space)) //  Jump
        {
            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
    }
}
