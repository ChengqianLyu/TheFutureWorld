using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTestTrigger : MonoBehaviour {

    [Header("Set in Inspector")]
    public AudioClip soundFile; //"AudioClip" Is used for the Actual .wav files.
    private AudioSource audioSource;

    void OnTriggerEnter(Collider playerCollider)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundFile;
        audioSource.Play();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
