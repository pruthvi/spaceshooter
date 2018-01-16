using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class scroll : MonoBehaviour {

    public float speed = 0.5f;
    public float size;
    private Vector2 startposition;
    // Use this for initialization
    void Start () {
        startposition = transform.position;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float newPosition = Mathf.Repeat(Time.time * speed, size);
        transform.position = startposition + Vector2.right * newPosition;
//        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
