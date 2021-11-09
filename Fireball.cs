using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody2D theRB;


    public GameObject snowBallEffect;



    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
            Destroy(gameObject);
            Instantiate(snowBallEffect, transform.position, transform.rotation);
        }

        if (other.tag == "Grounded")
        {
            Destroy(gameObject);
            Instantiate(snowBallEffect, transform.position, transform.rotation);


        }
        


    }
}   