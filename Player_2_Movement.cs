using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Movement : MonoBehaviour
{
    public int fire = 0;

    public float jumpForce;


    public float runSpeed = 0f;
    float HorizontalMove = 0f;
    public Controller_P1 controller;

    bool jump = false;
    bool crouch = false;




    private Rigidbody2D theRB;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;


    public bool isGrounded;

    private Animator anim;
    public GameObject fireBall;
    public Transform throwPoint;


    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        HorizontalMove = Input.GetAxisRaw("Horizontal_2") * runSpeed;
        anim.SetFloat("Speed", Mathf.Abs(HorizontalMove));



        if (Input.GetButtonDown("Jump2") && isGrounded)
        {

            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

        }
        if (theRB.velocity.x < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {

            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("throwBall"))
        {

            
            if (fire == 0) {
                fire = 1;
                GameObject ballClone = (GameObject)Instantiate(fireBall, throwPoint.position, throwPoint.rotation);
                ballClone.transform.localScale = transform.localScale;
                anim.SetTrigger("Throw");
                StartCoroutine("Fireball");

            }
            

        }



        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
    private void FixedUpdate()
    {
        // Move our Character
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }




    IEnumerator Fireball()
        {

        
        yield return new WaitForSeconds(0.25f);
        fire = 0;




    }






}
    