using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePaddleSize : BasePowerUp
{
    //How much units should the paddle change when this powerup is picked up?
    //Can also be negative to shrink the paddle!
    public Vector3 sizeIncrease = Vector3.zero;
    public Vector3 minPaddleSize = new Vector3 (0.1f, 0.1f, 0.4f);

    //Notice how we override the OnPickup method of the base class
    protected override void OnPickup ()
    {
        //Call the default behaviour of the base class first
        base.OnPickup ();

        //Then do the powerup specific behaviour, changing the size in this case
        Paddle paddle = FindObjectOfType (typeof (Paddle)) as Paddle;

        paddle.transform.localScale += sizeIncrease;            //Increase the size of the paddle by scaling it.

        //Limit the minimal size of the paddle
        Vector3 size = paddle.transform.localScale;

        if (size.x < minPaddleSize.x)
        {
            size.x = minPaddleSize.x;
        }

        if (size.y < minPaddleSize.y)
        {
            size.y = minPaddleSize.y;
        }

        if (size.z < minPaddleSize.z)
        {
            size.z = minPaddleSize.z;
        }

        paddle.transform.localScale = size;
    }
}
