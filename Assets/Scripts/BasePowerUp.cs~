using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D), typeof (Collider2D), typeof (AudioSource))]
public class BasePowerUp : MonoBehaviour
{
    //How fast does it drop?
    public float dropSpeed = 1;

    //Sound played when the powerup is picked up
    public AudioClip sound; 

    // Use this for initialization
    void Start ()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
    }

    // Update is called once per frame
    protected virtual void Update ()
    {
        
    }

    IEnumerator OnTriggerEnter2D (Collider2D other)
    {
        //Only interact with the paddle
        if (other.name == "Paddle")
        {
            //Notify the derived powerups that its being picked up
            OnPickup ();

            //Disable further collisions
            GetComponent<Collider2D> ().enabled = false;
            GetComponent<Renderer> ().enabled = false;

            //Change the sound pitch
            GetComponent<AudioSource> ().pitch = Time.timeScale;

            //Play audio and wait to the length of the of audio.
            GetComponent<AudioSource> ().PlayOneShot (sound);

            yield return new WaitForSeconds (sound.length);
        }
    }

    //Every powerup which derives from this class should implement this.
    protected virtual void OnPickup ()
    {
        
    }
}