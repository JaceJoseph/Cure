using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public GameObject Yeh;
    float[] direction = new float[5];
    Vector2[] directions = new Vector2[5];
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 1f, 3f);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FireEnemyBullet()
    {
        //Got a reference to the player ship
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            //compute the bullet's direction towards the player ship
            direction[0] = transform.position.x - 10f;
			direction[1] = transform.position.x - 5f;
            direction[2] = transform.position.x;
			direction[3] = transform.position.x + 5f;
            direction[4] = transform.position.x + 10f;

            //instantiate an enemy bull
            for (int i=0;i<5;i++)
            {
                directions[i] = new Vector2(direction[i], transform.position.y - 50f);
                GameObject bullet = (GameObject)Instantiate(Yeh, transform.position,Quaternion.identity);
                bullet.GetComponent<EB>().SetDirection(directions[i]);
               
            }
            

        }

    }
}
