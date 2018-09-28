using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES : MonoBehaviour {

    public GameObject Yeh;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FireEnemyBullet", 1f, 1f);

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FireEnemyBullet()
    {
        //Got a reference to the player ship
        GameObject playerShip = GameObject.Find("Player");

        if(playerShip != null)
        {
            //instantiate an enemy bull
            GameObject bullet = (GameObject)Instantiate(Yeh);

            //set bullet pos
            bullet.transform.position = transform.position;

            //compute the bullet's direction towards the player ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //set the bullet's direction
            bullet.GetComponent<EB>().SetDirection(direction);
        }

    }
}
