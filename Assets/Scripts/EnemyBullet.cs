using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    float speed;
    Vector2 _direction;
    bool isReady;

    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;

    }

	// Update is called once per frame
	void Update () {
		
        if(isReady)
        {
            //current position
            Vector2 position = transform.position;

            //new position
            position += _direction * speed * Time.deltaTime;

            //update position
            transform.position = position;

            //bottom-left
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            //top-right
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            if((transform.position.x<min.x) || (transform.position.x>max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
                {
                Destroy(gameObject);
                }
        }


    }
}
