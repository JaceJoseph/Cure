using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner2 : MonoBehaviour {
    public GameObject EnemyGO;
    float maxSpawnRateinSeconds = 5f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateinSeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2 (Random.Range(min.x,max.x),max.y);

        ScheduleNextESpawn();
    }

    void ScheduleNextESpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateinSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateinSeconds);

        }
        else
            spawnInSeconds = 3f;

        Invoke("SpawnEnemy", spawnInSeconds);
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateinSeconds > 1f) maxSpawnRateinSeconds--;
        if (maxSpawnRateinSeconds == 1f) CancelInvoke("IncreaseSpawnRate");
    }

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRateinSeconds);

        //increase spawn rate every 10sec
        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}

