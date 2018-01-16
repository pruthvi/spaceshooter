using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject playButton;
    public GameObject Ship;

    public enum GameManagerState
    {
        Opening, Gameplay, GameOver,
    }

    GameManagerState GMState;


	// Use this for initialization
	void Start () {
        GMState = GameManagerState.Opening;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
