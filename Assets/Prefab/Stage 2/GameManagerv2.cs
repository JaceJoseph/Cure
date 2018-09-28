using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerv2 : MonoBehaviour {

	public GameObject playerShip;
	public GameObject enemySpawnner;
	public GameObject GameOverGO;
	public GameObject GameOverGO_1;
	public GameObject GameOverGOV;
	public GameObject GameOverGO_1V;
	public GameObject Background;
	public GameObject Lives;
	public GameObject NLives;
    public static int CountWin;

	public enum GameManagerState{
		Gameplay,
		GameOver,
		Victory
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {
        CountWin = 0;
		GMState = GameManagerState.Gameplay;
		Debug.Log ("c");
		Lives.SetActive (false);
		Debug.Log ("d");

		Background.SetActive(true);
		playerShip.GetComponent<PM>().init();
		enemySpawnner.GetComponent<EnemySpawnner2>().ScheduleEnemySpawner();
	}

	void UpdateGameManagerState()
	{
		switch(GMState){
		case GameManagerState.Gameplay:

			
		break;

		case GameManagerState.GameOver:
			enemySpawnner.GetComponent<EnemySpawnner2>().UnscheduleEnemySpawner();
			GameOverGO_1.SetActive(true);
			break;

		case GameManagerState.Victory:
			enemySpawnner.GetComponent<EnemySpawnner2>().UnscheduleEnemySpawner();
			GameOverGO_1V.SetActive(true);
                Destroy(playerShip);
			break;

		}

	}

    private void Update()
    {
        if (CountWin >= 10)
        {
            Debug.Log("WIN");
            GMState = GameManagerState.Victory;
            UpdateGameManagerState();
        }
    }
    public void SetGameManagerState (GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState();
	}
		
	public void ChangeToOpeningState()
	{
        Application.LoadLevel(0);
	}

    public void ChangeScene()
    {
        Application.LoadLevel(6);
    }
}
