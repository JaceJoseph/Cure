using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManajerv3 : MonoBehaviour {

	public GameObject playerShip;
	public GameObject enemySpawnner;
	public GameObject GameOverGO;
	public GameObject GameOverGO_1;
	public GameObject GameOverGOV;
	public GameObject GameOverGO_1V;
	public GameObject Background;
	public GameObject Lives;
	public GameObject NLives;
    public bool bossSpawnActive;
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
		Lives.SetActive (true);
		Debug.Log ("d");


        Background.SetActive(true);
		playerShip.GetComponent<PMS3>().init();
		enemySpawnner.GetComponent<EnemySpwan>().ScheduleEnemySpawner();
	}

	void UpdateGameManagerState()
	{
		switch(GMState){
		case GameManagerState.Gameplay:
            bossSpawnActive = true;
            if (CountWin == 1)
			{
				Debug.Log("WIN");

			}
		break;

		case GameManagerState.GameOver:
			enemySpawnner.GetComponent<EnemySpwan>().UnscheduleEnemySpawner();
             bossSpawnActive = false;
               GameOverGO.SetActive(true);
			GameOverGO_1.SetActive(true);
			break;

		case GameManagerState.Victory:
			enemySpawnner.GetComponent<EnemySpwan>().UnscheduleEnemySpawner();
			GameOverGOV.SetActive(true);
                bossSpawnActive = false;
                Destroy(playerShip);
			break;

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
        Application.LoadLevel(1);
    }
}
