using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float damage = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Patrol")
        {
            moveSpeed *= -1;
        }
        if(collision.gameObject.tag == "Player")
        {
            PlayerManager pm = collision.gameObject.GetComponent<PlayerManager>();
            pm.BeDamaged(damage);
        }
    }

}
