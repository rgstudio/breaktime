using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class Paddle : MonoBehaviour
{
    public int i = 0;
    //Make the AudioClip configurable in the editor
    public AudioClip sound;

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        //Set variable for current position
        Vector3 paddlePosition = new Vector3 (8f, this.transform.position.y, 0f);

        //Get mouse position
        float mousePosition = Input.mousePosition.x / Screen.width * 16f;       //Get the mouse position (as World Transform component units) on the X-component and scale it to 16.0f (screen width size).
        print (Input.mousePosition);
        print (Screen.width);

        //Set new mouse X position
        paddlePosition.x = Mathf.Clamp (mousePosition, 0.5f, 15.5f);            //Clamps the paddle position to the screen width dimensions (0.5f to 15.5f).

        //Change paddle gameobject position to match new X position
        this.transform.position = paddlePosition;
    }

    //OnCollisionEnter will only be called when one of the colliders has a rigidbody
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            other.gameObject.GetComponent<TrailRenderer> ().enabled = true;
        }

        //Change the sound pitch if a slowdown powerup has been picked up
        GetComponent<AudioSource> ().pitch = Time.timeScale;

        //Play it once for this collision hit
        GetComponent<AudioSource> ().PlayOneShot (sound);
    }

    IEnumerator OnCollisionExit2D (Collision2D other)
    {
        yield return new WaitForSeconds (.25f);

        if (other.gameObject.name == "Ball")
        {
            other.gameObject.GetComponent<TrailRenderer> ().enabled = false;
        }
    }
}
