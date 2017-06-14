using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string _finishTime;
    private int bricksCount = 0;
    private GameObject[] _bricks;
    private GameManager _gameManager;

    // Use this for initialization
    void Start ()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager> ();
    }

    // Update is called once per frame
    void Update ()
    {
        _bricks = GameObject.FindGameObjectsWithTag ("Brick");
        Debug.Log ("Brick Count: " + _bricks.Length);
        bricksCount = _bricks.Length;

        if (bricksCount == 0)
        {
            Debug.Log ("All bricks are gone!");
            //Wait before returning to Main level
            StartCoroutine (Pause ());
        }
    }

    IEnumerator Pause ()
    {
        print ("Before Waiting 5 seconds");

        //Switch GameManager State
        _gameManager.SwitchState (GameState.Completed);
        _gameManager.ChangeText ("You Cleared The Level :)");

        _finishTime = _gameManager.formattedTime;

        Debug.Log ("Took " + _finishTime + " to finish the game");
        yield return new WaitForSeconds (5);

        //Reload Main Menu
        LoadScene (0);
        print ("After Waiting 5 Seconds went to main menu");
    }

    public void LoadScene (int level)
    {
        SceneManager.LoadScene (level);
    }
}