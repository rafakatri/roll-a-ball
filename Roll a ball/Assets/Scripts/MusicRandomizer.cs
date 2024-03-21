using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSound : MonoBehaviour {
 
    public AudioClip[] music;
    public int pickedSound; 
    private AudioSource source;
    void Start () {
        pickedSound = Random.Range(0, music.Length); 
        source = GetComponent<AudioSource>();
        source.clip = music[pickedSound];
        source.Play(); 
    }
   
    void Update () {
        if (!source.isPlaying)
        {
            if (pickedSound == 0){
                pickedSound = 1;
                source.clip = music[pickedSound];
                source.Play();
            }
            else {
                pickedSound = 0;
                source.clip = music[pickedSound];
                source.Play();
            }
        }
    }
}