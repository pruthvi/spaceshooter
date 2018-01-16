using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;   // Spawned enemies
    public GameObject shipHazard;
    public Vector2 spawnValue;  // Where do enemies spawn?
    public int hazardCount; // How many enemies?
    public float startWait; // How long do we wait for the 1st wave
    public float spawnWait; // How long between each asteroid spawn?
    public float waveWait; // How long between waves of enemies

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
    public Text timeUI;
    public Text hsText;

    private bool gameOver;
    private bool restart;
    public int score;

    public int life;

    public float startTime;
    public float ellapsedTime;
    public bool startCounter;
    public int minutes;
    public int seconds;

    private int waveCount = 0;
    public int highscore;


    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        startCounter = false;
        life = 3;

        scoreText.text = "";
		restartText.text = "";
		gameOverText.text = "";
        hsText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highscore").ToString();
        
        timeUI.text = "TIME: 00:00";

        score = 0;
		UpdateScore ();
        StartCoroutine(SpawnWaves()); // Starts and calls my coroutine
        StartTimeCounter();

    }
	
	// Update is called once per frame
	void Update () 
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				// Application.LoadLevel (Application.loadedLevel); -- DECPRICATED
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}


        //Counter
        if (startCounter)
        {
            ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            timeUI.text = string.Format("TIME:    {00:00}m   {1:00}s", minutes, seconds);
        }

        if(minutes>5)
        {
            Win();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            if (waveCount <= 3)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);

                }
            }
            else
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(shipHazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);

                }
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                StopTimeCounter();
                StopTimeCounter();
                restartText.gameObject.SetActive (true);
				restartText.text = "Press R for Restart";
                restart = true;
                break;

            }

            waveCount++;
        }
    }

	public void AddScore(int newScoreValue) 
	{
		score += newScoreValue;
		UpdateScore();
	}

    void UpdateScore()
    {
		scoreText.text = "SCORE : " + score.ToString();

        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            hsText.text = "HIGH SCORE: " + score.ToString();
        }

        if (score > 2000)
        {
            Win();
        }

    }

    public void Win()
    {
        StopTimeCounter();
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You WON!";
        gameOver = true;
    }

	public void GameOver() 
	{

		gameOverText.gameObject.SetActive (true);
		gameOverText.text = "Game Over!";
		gameOver = true;
    }

    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }
    public void StopTimeCounter()
    {
        startCounter = false;
    }



}
