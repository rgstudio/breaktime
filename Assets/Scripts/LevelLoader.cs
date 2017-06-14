using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	private GameObject _quitButton;

    //Basic function for loading level
    public void LoadScene (int level)
    {
        SceneManager.LoadScene (level);
    }

	public void QuitGame ()
	{
		if (Application.isEditor)
		{
			Debug.Log ("Attempted to quit from the Editor.");
		}

		else if (Application.isWebPlayer)
		{
			_quitButton = GameObject.FindGameObjectWithTag ("Quit");
			_quitButton.SetActive (false);
			Debug.Log ("Attempted to quit from the Web Player.");
		}

		else if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			_quitButton = GameObject.FindGameObjectWithTag ("Quit");
			_quitButton.SetActive (false);
			Debug.Log ("Attempted to quit from the WebGL Player.");
		}

		else
		{
			Application.Quit ();
		}
	}
}