using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Controller_P1 controller;
    public Animator animator;
    public float runSpeed = 0f;
    float HorizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

  

	void Update () {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {

            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) 
            
            crouch = false;
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");

        }
    }
	
    public void OnLanding ()
    {

        animator.SetBool("IsJumping", false);

    }

    public void OnCrouching(bool isCrouching)
    {

        animator.SetBool("IsCrouching", isCrouching);



    }
    private void FixedUpdate()
    {
        // Move our Character
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


}
