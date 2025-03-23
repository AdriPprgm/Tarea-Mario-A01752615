//Adrian Proano Bernal A01752615

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;

    public CapsuleCollider2D capsule;

    public float speed;

    public float jumpPower;
    
    private Animator animationhandler;

    private SpriteRenderer spRender;

    private bool isGrounded = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animationhandler = GetComponent<Animator>();
        spRender = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animationhandler.SetFloat("velocity", Math.Abs(body.linearVelocityX));
        animationhandler.SetBool("onground", isGrounded);

        if(body.linearVelocityX < 0){
            spRender.flipX = true;
        }
        else{   
            spRender.flipX = false;
        }

        float xInput = Input.GetAxis("Horizontal");
        bool yInput = Input.GetKey(KeyCode.W);

        if (yInput && isGrounded){
            //body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            body.linearVelocityY = jumpPower;
        }

        body.linearVelocity = new Vector2(xInput * speed, body.linearVelocityY);
        
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
