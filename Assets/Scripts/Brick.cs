using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource), typeof (Animation))]
public class Brick : MonoBehaviour
{
    public int maxHits;

    //Make the AudioClip and Pitch modifiable in the editor
    public AudioClip sound;
    public float pitchStep = 0.05f;
    public float maxPitch = 1.3f;

    //Make the current pitch value global
    public static float pitch = 1;

    //Falling variables
    public bool fallDown = false;

    [HideInInspector]
    public bool blockIsDestroyed = false;

    private int _timesHit;
    private bool _brickIsDestroyed = false;
    private Vector2 _velocity = Vector2.zero;

    // Use this for initialization
    void Start ()
    {
        _timesHit = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if (fallDown && _velocity != Vector2.zero)
        {
            Vector2 position = (Vector2) transform.position;
            position += _velocity * Time.deltaTime;
        }
    }

    void OnBecameInvisible ()
    {
        blockIsDestroyed = true;
        Destroy (gameObject);
    }

    private IEnumerator OnCollisionExit2D (Collision2D other)
    {
        if (_timesHit == maxHits)
        {
            print ("Destroyed on Exit!");
            print ("Play Woggle!");

            GetComponent<Collider2D> ().enabled = false;                                //Disable the collider.

            //Play the Woggle animation
            GetComponent<Animation> ().Play ();

            //Wait here for the length of the Woggle animation
            yield return new WaitForSeconds (GetComponent<Animation> () ["Woggle"].length);
            
            //Animation Woggle has finished, now decide what to do, falldown or just disappear
            if (fallDown)
            {
                print ("Falling!");
                //Falldown to the direction the ball hit it, with a random speed and plus a little downwards "gravity"
                _velocity = new Vector2 (0, Random.Range (1, 10.0F) * -1);              //Make the Y-component negative so it the brick will fall down.
            }

            else
            {
                GetComponent<Renderer> ().enabled = false;                              //Hide the brick from the scene.
            }

            Destroy (gameObject);
        } 

        else
        {
            print ("Max hits not reached");
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        _timesHit++;

        print ("Ouch you hit me this many times: " + _timesHit);
        print ("Playing brick sound!");

        //Increase pitch
        pitch += pitchStep;

        //Limit pitch
        if (pitch > maxPitch)
        {
            pitch = 1;              //Reset pitch to one so it starts over with the lower tone
        }

        //Apply pitch
        GetComponent<AudioSource> ().pitch = pitch;

        //Play it once for this collision hit
        GetComponent<AudioSource> ().PlayOneShot (sound);

        StartCoroutine (OnCollisionExit2D (other));
    }
}
