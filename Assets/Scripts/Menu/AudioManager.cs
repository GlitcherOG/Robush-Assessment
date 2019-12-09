using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source; //The audio source
    public AudioClip[] clip; //Audio clips

    public void Death()
    {
        //Pause the audio coming from the source
        source.Pause();
        //Set the audio clip to play
        source.clip = clip[0];
        //Play the clip
        source.Play();
    }

    public void ButtonClick()
    {
        //Pause the audio coming from the source
        source.Pause();
        //Set the audio clip to play
        source.clip = clip[1];
        //Play the clip
        source.Play();
    }
}
