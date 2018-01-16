using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    float speed;

	// Use this for initialization
	void Start () {
        speed = 2f;	
	}
	
	// Update is called once per frame
	void Update () {
        //current position
        Vector2 position = transform.position;

        //new position
//        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        position = new Vector2(position.x - speed * Time.deltaTime,position.y);

        //update position
        transform.position = position;


        //bottom left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //destroy, if out of the screen
        if(transform.position.y <min.y)
        {
            Destroy(gameObject);
        }
	}
}
