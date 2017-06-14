using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//List of all the possible gamestates
public enum GameState
{
    NotStarted,
    Playing,
    Completed,
    Failed
}

//Require an audio source for the object
[RequireComponent (typeof (AudioSource))]
public class GameManager : MonoBehaviour
{
    //Sounds to be played when entering one of the gamestates
    public AudioClip StartSound;
    public AudioClip FailedSound;
    public float Timer = 0.0f;
    public string formattedTime;
    public Text text;

    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject buttonBackground;

    private GameState _currentState = GameState.NotStarted;         //Default gamestate.
    //All the bricks found in this level, to keep track of how many are left
    private Brick[] _allBricks;
    private Ball[] _allBalls;
    private Paddle _paddle;
    private int _minutes;
    private int _seconds;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;

        //Find all the blocks in this scene
        _allBricks = FindObjectsOfType (typeof (Brick)) as Brick[];         //Get all the Brick[] inside the Game.

        //Find all the balls in this scene
        _allBalls = FindObjectsOfType (typeof (Ball)) as Ball[];            //Get all the Ball[].
        _paddle = GameObject.FindObjectOfType<Paddle> ();                   //Get all the Paddle game object in the Game.

        print ("Bricks: " + _allBricks.Length);
        print ("Balls: " + _allBalls.Length);
        print ("Paddle: " + _paddle.name);

        //Change start text
        ChangeText ("Click To Begin");

        //Prepare the start of the level
        SwitchState (GameState.NotStarted);
    }

    // Update is called once per frame
    void Update ()
    {
        switch (_currentState)
        {
            case GameState.NotStarted:
                //Change start text
                ChangeText ("Click To Begin");

                //Check if the player taps/clicks.
                if (Input.GetMouseButtonDown (0))       //Note: on mobile this will translate to the first touch/finger so perfectly multiplatform!
                {
                    SwitchState (GameState.Playing);
                }
                break;

            case GameState.Playing:
                {
                    Timer += Time.deltaTime;
                    _minutes = Mathf.FloorToInt (Timer / 60f);
                    _seconds = Mathf.FloorToInt (Timer - _minutes * 60);
                    formattedTime = string.Format ("{0:0}:{1:00}", _minutes, _seconds);

                    //Change start text
                    ChangeText ("Time: " + formattedTime);

                    bool allBlocksDestroyed = false;

                    //Are there no balls left?
                    if (FindObjectOfType (typeof (Ball)) == null)
                    {
                        SwitchState (GameState.Failed);
                    }

                    if (allBlocksDestroyed)
                    {
                        SwitchState (GameState.Completed);
                    }
                }
                break;

        //Both cases do the same: restart the game
            case GameState.Failed:
                print ("Gamestate Failed!");

                ChangeText ("You Lose :(");

                break;

            case GameState.Completed:
                bool allBlocksDestroyedFinal = false;
                //Destroy all the balls
                Ball[] balls = FindObjectsOfType (typeof (Ball)) as Ball[];

                foreach (Ball ball in balls)          //Loop thru all the balls in the game...
                {
                    Destroy (ball.gameObject);         //Destroy the ball.
                }
                break;
        }
    }

    public void EnableButtons ()
    {
        //Enable buttons for when the player loses
        restartButton.SetActive (true);
        mainMenuButton.SetActive (true);
        buttonBackground.SetActive (true);
    }

    public void ChangeText (string text)
    {
        //Find Canvas and modify text
        GameObject canvas = GameObject.Find ("Canvas");                 //Get the canvas game object.

        Text[] textValue = canvas.GetComponentsInChildren<Text> ();     //
        textValue [0].text = text;
    }

    public void SwitchState (GameState newState)
    {
        _currentState = newState;

        switch (_currentState)
        {
            default:
                
            case GameState.NotStarted:
                break;

            case GameState.Playing:
                GetComponent<AudioSource> ().PlayOneShot (StartSound);
                break;

            case GameState.Completed:
                GetComponent<AudioSource> ().PlayOneShot (StartSound);
                break;

            case GameState.Failed:
                GetComponent<AudioSource> ().PlayOneShot (FailedSound);
                break;
        }
    }
}