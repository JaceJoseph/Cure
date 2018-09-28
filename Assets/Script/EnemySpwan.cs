using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour {

    float maxSpawnRateinSeconds = 3f;
    //public GameObject EnemyC;
    //public GameObject EnemyA;
    public GameObject[] enemy;
    int random;
    GameObject Enemy;
    public parallax p;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*if (p.Pos.y == -9.91f)
        {
            UnscheduleEnemySpawner();
        }*/
	}

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //GameObject anEnemy = (GameObject)Instantiate(EnemyC);
        //GameObject aEnemy = (GameObject)Instantiate(EnemyA);
        random = Random.Range(0, 100);
        if(random < 30)
        {
            Enemy = Instantiate(enemy[1]);
        }
        if (random>30 && random <60){
            Enemy = Instantiate(enemy[2]);
        }
        else
        {
            Enemy = Instantiate(enemy[0]);
        }
        
        Enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        //anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        //aEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

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
        InvokeRepeating("IncreaseSpawnRate", 0f, 20f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
