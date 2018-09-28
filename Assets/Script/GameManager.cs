using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawnner;
    public GameObject GameOverGO;
    public GameObject GameOverGO_1;
    public GameObject GameOverGOV;
    public GameObject GameOverGO_1V;
    public GameObject Background;
    public GameObject BackgroundA;
    public GameObject ButtonSwap;
    public GameObject Lives;
    public GameObject NLives;
    public bool bossSpawnActive;
    public GameObject catalogbutton;
    public GameObject SelectLevel;

    public enum GameManagerState
    {
        Opening,
        LevelSelect,
        Gameplay,
        GameOver,
        Victory
           
    }
    GameManagerState GMState;

    // Use this for initialization
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                playButton.SetActive(true);
                catalogbutton.SetActive(true);
                Lives.SetActive(false);
                NLives.SetActive(false);
                ButtonSwap.SetActive(false);
                bossSpawnActive = false;
                BackgroundA.SetActive(true);
                break;
            case GameManagerState.LevelSelect:
                SelectLevel.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                playButton.SetActive(false);
                Lives.SetActive(true);
                catalogbutton.SetActive(false);
                NLives.SetActive(false);
                ButtonSwap.SetActive(true);
                BackgroundA.SetActive(false);
                playerShip.GetComponent<PMS2>().init();
                bossSpawnActive = true;
                enemySpawnner.GetComponent<EnemySpwan>().ScheduleEnemySpawner();
                break;

            case GameManagerState.GameOver:
                enemySpawnner.GetComponent<EnemySpwan>().UnscheduleEnemySpawner();
                bossSpawnActive = false;
                GameOverGO.SetActive(false);
                GameOverGO_1.SetActive(true);
                break;

            case GameManagerState.Victory:
                enemySpawnner.GetComponent<EnemySpwan>().UnscheduleEnemySpawner();
                bossSpawnActive = false;
                GameOverGOV.SetActive(true);
                GameOverGO_1V.SetActive(true);
                break;



        }
    }
    public void SetGameManagerState (GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        SelectLevel.SetActive(false);
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
        Background.transform.position = new Vector3(11.6f, 20.6f,19.2f);
    }

    public void LevelSelect()
    {
        GMState = GameManagerState.LevelSelect;
        UpdateGameManagerState();
    }

    public void Level2()
    {
        Application.LoadLevel(1);
    }

    public void Level3()
    {
        Application.LoadLevel(6);
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    public void changeScene()
    {
        Application.LoadLevel(0);
    }
    public void changeSceneVictory()
    {
        Application.LoadLevel(1);
    }
}
