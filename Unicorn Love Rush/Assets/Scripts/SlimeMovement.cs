using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float damage = 1.0f;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Patrol")
        {
            moveSpeed *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager pm = collision.gameObject.GetComponent<PlayerManager>();
            pm.BeDamaged(damage);
        }
    }
}
