using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FootStepAudio : MonoBehaviour
{

    RigidbodyFirstPersonController control;
    private AudioSource aud;

    public AudioClip footstep1;
    public AudioClip Jump;
    public AudioClip landing;
    


    void Start()
    {
        control = GetComponent<RigidbodyFirstPersonController>();
        aud = GetComponent<AudioSource>();
    }

    
    void Update()
    {

        if (control.Grounded && control.Velocity.magnitude > 2f && !aud.isPlaying)
        {
            aud.clip = footstep1;
            aud.Play();
        }

        if (control.Jumping && !control.Grounded && !aud.isPlaying && !control.JumpedSound)
        {
            control.JumpSound = true;
            aud.clip = Jump;
            aud.Play();
            
        }

        if(control.Grounded && !aud.isPlaying && !control.JumpedSound && !control.land)
        {
            control.landed = true;
            aud.clip = landing;
            aud.Play();
        }
    }
}
