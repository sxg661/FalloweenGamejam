﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {


    //THIS WAS NOT WRITTEN BY ME
    
    AudioSource fxSound; // Emitir sons
    public AudioClip backMusic; // Som de fundo
                                // Use this for initialization
    void Start()
    {
        // Audio Source responsavel por emitir os sons
        fxSound = GetComponent<AudioSource>();
        fxSound.Play();
    }
}
