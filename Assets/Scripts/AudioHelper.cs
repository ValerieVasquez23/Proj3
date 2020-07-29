using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public static AudioSource PlayerClip2D(AudioClip clip, float volume){
        //create our new audioScource
        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //configure to 2D
        audioSource.clip = clip;
        audioSource.volume = volume;
        //play the audio
        audioSource.Play();
        //destory when its done
        Object.Destroy(audioObject, clip.length);
        //return it
        return audioSource;
    }

}
