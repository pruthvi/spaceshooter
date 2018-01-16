using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;

    float spawnRate = 5f;

	// Use this for initialization
	void Start () {
        Invoke("SpawnEnemy", spawnRate);

        //increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        //bottom-left
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //top-right
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));


        GameObject anEmeny = (GameObject)Instantiate(Enemy);
        anEmeny.transform.position = new Vector2(Random.Range(min.y, max.y), max.x);

        ScheduleNextEnemy();
    }
    void ScheduleNextEnemy()
    {
        float spawnInSec;
        if (spawnRate > 1f)
        {
            spawnInSec = Random.Range(1f, spawnRate);
        }
        else
            spawnInSec = 1f;
        Invoke("SpawnEnemy", spawnInSec);
    }
     void IncreaseSpawnRate()
    {
        if (spawnRate > 1f)
            spawnRate--;
        if (spawnRate == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

}
