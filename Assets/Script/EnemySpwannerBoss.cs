using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwannerBoss : MonoBehaviour {
    Vector3 Pos;
    public GameObject Creep;
    float[] direction = new float[2];
    Vector2[] directions = new Vector2[2];
    public GameObject aku;
    float count = 0;
    // Use this for initialization
    void Start () {
        InvokeRepeating("SummonCreep", 1f, 4f);
    }
	
	// Update is called once per frame
	void Update () {
        if(count >= 151)
        {
            GameObject.Find("GameManagerGO").GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
            Destroy(gameObject);
            
        }
        Pos = transform.position;
        Pos.y = Mathf.Clamp(Pos.y, 3f, 5f);
        transform.position = Pos;
        transform.Translate(0, -1f * Time.deltaTime, 0);

       
    }
    
    void SummonCreep()
    {
        //Got a reference to the player ship
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            //compute the bullet's direction towards the player ship
            direction[0] = transform.position.x - Random.Range(5f, 45f);
            direction[1] = transform.position.x + Random.Range(5f, 45f);

            //instantiate an enemy bull
            for (int i = 0; i < 2; i++)
            {
                directions[i] = new Vector2(direction[i], transform.position.y - 50f);
                GameObject creep = Instantiate(Creep, new Vector3(transform.position.x,transform.position.y,-1f), Quaternion.identity);
                creep.GetComponent<BossCreepMovement>().SetDirection(directions[i]);

            }


        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "PlayerBullet")
        {
            count++;
        }
    }
}
