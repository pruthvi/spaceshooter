using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

    public GameObject EnemyBullet;
	
	// Update is called once per frame
	void Start () {
        FireEnemyBullet();
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Ship");

        if(playerShip != null)
        {
            //instantiate enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            //set position
            bullet.transform.position = transform.position;

            //find bullet direction towards ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //set direction
            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * 5;
        }
    }

}
