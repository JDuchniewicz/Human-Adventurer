using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    float speed = 50.0f;
    [SerializeField]
    float maxSpeed = 3.0f;
    [SerializeField]
    float jumpPower = 150.0f;
    [SerializeField]
    float scale = 1.0f;

    public bool grounded;

    Rigidbody2D rb2;
    Animator anim;

	// Use this for initialization
	void Start () {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector2(-scale, scale);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector2(scale, scale);
        }

    }
    

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2.AddForce((Vector2.right * speed) * h);
        if(rb2.velocity.x > maxSpeed)
        {
            anim.SetBool("IsWalking", true);
            rb2.velocity = new Vector2(maxSpeed, rb2.velocity.y);
        }

        if (rb2.velocity.x < -maxSpeed)
        {
            anim.SetBool("IsWalking", true);
            rb2.velocity = new Vector2(-maxSpeed, rb2.velocity.y);
        }
        if(rb2.velocity.x == 0)
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            anim.SetBool("IsWalking", false);
            rb2.AddForce(Vector2.up * jumpPower);
            anim.SetBool("IsJumping", true);
        }
    }


   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Block"))
        {
            if (anim)
            {
                anim.SetBool("IsJumping", false);
                grounded = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Block"))
        {
            grounded = false; //add some kind of timer of jumps
        }
    }
}
