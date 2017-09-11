using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer inst = null;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (inst)
        {
            Destroy(gameObject);
        } else
        {
            inst = this;
            DontDestroyOnLoad(transform.gameObject);
        }

    }
	// Use this for initialization
	void Start () {

 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
