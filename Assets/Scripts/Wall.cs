﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sure there is always an AudioSource component on the GameObject where this script is added.
[RequireComponent (typeof (AudioSource))]
public class Wall : MonoBehaviour
{
    //Make the AudioClip and Pitch configurable in the editor
    public AudioClip sound;

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        print ("Ouch you hit my wall!");
        //Play it once for this collision hit
        GetComponent<AudioSource> ().PlayOneShot (sound);
    }
}
