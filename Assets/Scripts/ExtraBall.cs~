using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : BasePowerUp
{
    //BallPrefab instantiated when the powerup is picked up
    public GameObject ballPrefab;

    //Make the min and max speed to be configurable in the editor.
    public float minimumSpeed = 10f;
    public float maximumSpeed = 20f;

    //To prevent the ball from keep bouncing horizontally we enforce a minimum vertical movement
    public float minimumVerticalMovement = 0.5f;

    //Override of the OnPickup method of the base class
    protected override void OnPickup ()
    {
        //Call the default behaviour of the base class first
        base.OnPickup ();
        print ("On pickup Call!");
    }

    void Update ()
    {
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        print ("Extra Collison");

        if (other.gameObject.tag == "Paddle")
        {
            print ("Extra Collison Paddle");
            launchBall ();
        }
    }

    public void launchBall ()
    {
        //Get current speed and direction
        Vector2 direction = GetComponent<Rigidbody2D> ().velocity;

        //float speed = 20f;
        float speed = direction.magnitude;
        direction.Normalize ();

        //Make sure the ball never goes straight horizotal else it could never come down to the paddle.
        if (direction.x > -minimumVerticalMovement && direction.x < minimumVerticalMovement)
        {
            //Adjust the x, make sure it goes in a direction within the range limit set
            direction.x = direction.x < 0 ? -minimumVerticalMovement : minimumVerticalMovement;

            //Adjust the y, make sure it keeps going into the direction it was going (up or down)
            direction.y = direction.y < 0 ? -1 + minimumVerticalMovement : 1 - minimumVerticalMovement;

            //Apply it back to the ball
            GetComponent<Rigidbody2D> ().velocity = direction * speed;
        }

        if (speed < minimumSpeed || speed > maximumSpeed)
        {
            //Limit the speed so it always above min and below max
            speed = Mathf.Clamp (speed, minimumSpeed, maximumSpeed);
            //Apply the limit

            //Note that we don't use * Time.deltaTime here since we set the velocity once, not every frame.
            GetComponent<Rigidbody2D> ().velocity = direction * speed;
        }
    }
}
