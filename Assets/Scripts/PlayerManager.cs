using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    Rigidbody2D rb2;
    GameController gm;
    LevelManager lm;
    CameraMovement cm;

    // Use this for initialization
    void Start () {
        rb2 = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameController>();
        lm = FindObjectOfType<LevelManager>();
        cm = FindObjectOfType<CameraMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   public void BeDamaged(float amount)
    {
        gm.DeductHealth(amount);
        if(gm.currentHealthValue <= 0)
        {
            lm.lost = true;
            cm.enabled = false;
            //internally animation sound etc
        } else
        {
            //animation
        }

    }

 
}
