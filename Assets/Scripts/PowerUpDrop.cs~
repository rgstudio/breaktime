using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class PowerUpDrop : MonoBehaviour
{
    public BasePowerUp powerUpPrefab;

    //OnCollision create the powerup
    void OnCollisionEnter2D (Collision2D other)
    {
        GameObject.Instantiate (powerUpPrefab, this.transform.position, Quaternion.identity);
    }
}