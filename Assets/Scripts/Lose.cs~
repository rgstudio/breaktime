using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Bottom wall collider's class that determines if the ball was not catched by the Player.
public class Lose : MonoBehaviour
{
    private Ball _ball;
    private GameManager _gameManager;

    public GameObject[] players;
    public GameObject[] extras;

    void Start ()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager> ();
    }

    IEnumerator Pause ()
    {
        print ("Before Waiting 2 seconds");

        //Switch GameManager State
        _gameManager.SwitchState (GameState.Failed);

        //enable the restart and main menu buttons
        _gameManager.EnableButtons ();

        //Commented so that the script will show the Restart and Main Menu buttons, instead of automatically restarting the level when the Player is dead.
//        
//        //Find the ball and reset game start
//        _ball = GameObject.FindObjectOfType<Ball> ();
//        _ball.gameStarted = false;
//        
//        //Reload level
//        SceneManager.LoadScene (1);

        yield return new WaitForSeconds (2);          
        print ("After Waiting 2 Seconds");
    }

    void OnTriggerEnter2D (Collider2D trigger)
    {
        if (trigger.name == "Ball")
        {
            print ("Lost Triggered!");

            //Wait before restarting level
            StartCoroutine (Pause ());
        }
    }
}