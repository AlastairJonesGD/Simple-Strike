using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    // Reference to the Players

    public int P1Life;
    public int P2Life;

    public GameObject P1Wins;
    public GameObject P2Wins;
    // Win Screens
    public GameObject[] P1Stick;
    public GameObject[] P2Stick;
    // Health for Each Character

    public string mainMenu;
	
	
	// Update is called once per frame
	void Update () {
		if(P1Life <= 0)    // If P1 Life is less than or equal to 0, run this function
        {
            player1.SetActive(false);     // Sets the Player 1 model to false, will deactive it
            P2Wins.SetActive(true);       // Sets the P2 Win screen to true calling it into the scene

            
        }
        if (P2Life <= 0)
        {
            player1.SetActive(false);  // Same as P1 script but for 2
            P1Wins.SetActive(true);
        }

        if(Input.GetButtonDown("Restart"))  // Button To Restat the Game
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetButtonDown("Main Menu"))  // Button To Go To Main Menu.
        {

            SceneManager.LoadScene(mainMenu);
        }
    }

    public void HurtP1()
    {
        P1Life -= 1;     // Everytime the player takes a damage it takes away 1 life
        Debug.Log("P1HURT");
        for(int i = 0; i < P1Stick.Length; i++)
        {

            if(P1Life > i)
            {

                P1Stick[i].SetActive(true);    // If P1 life script runs keep the stick 
            } else
            {
                P1Stick[i].SetActive(false);    // If P1 life script runs remove a stick
            }

        }

        
    }
    public void HurtP2()
    {
        P2Life -= 2;
        Debug.Log("THISWORKS");

        for (int i = 0; i < P2Stick.Length; i++)
        {

            if (P2Life > i)
            {

                P2Stick[i].SetActive(true);
                
            }
            else
            {
                P2Stick[i].SetActive(false);
            }

        }
    }
 
 
}
