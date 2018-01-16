using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {
   public float speed;

    // Use this for initialization
    void Start () {
        Vector2 position = transform.position;

        position = new Vector2(position.x - speed * Time.deltaTime, position.y);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < min.x)
        {
            transform.position = new Vector2(Random.Range(min.y, max.y), max.x);
        }
    }
	
	// Update is called once per frame
	void Update () {

    

    }
}
