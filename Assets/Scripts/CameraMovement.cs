using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    GameObject PlayerToFollow;
    public float offset = -9.5f;
	// Use this for initialization
	void Start () {
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float xPos = PlayerToFollow.transform.position.x;
        Vector3 pos = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.position = pos;
	}
}
