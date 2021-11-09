using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_P2 : MonoBehaviour {

  

        void OnTriggerEnter2D(Collider2D other)
        {
          
            if (other.tag == "Player2")
            {
                FindObjectOfType<GameManager>().HurtP2();

            }




            
        }



    }

