using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_P1 : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();

        }





    }

}
