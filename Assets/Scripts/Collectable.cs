using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public int value = 1;
    GameController gm;
    AudioSource audioSource;
    public AudioClip clip;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameController>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.AddCoins(value);
            gm.UpdateScore(value * 100);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
        }
    }
}
