using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ems : MonoBehaviour {
    public GameObject Yeh;
    float[] direction = new float[5];
    public Vector2 directions;
    public float SpawnSpeed;
    public Vector2 offset;
    public float RotateSpeed;
    public float Radius;
    public float _angle;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 1f, SpawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        //        directions = new Vector2(0.1f, 0f);
    }

    void FireEnemyBullet()
    {
        //Got a reference to the player ship
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            /* //compute the bullet's direction towards the player ship
             direction[0] = transform.position.x - 10f;
             direction[1] = transform.position.x - 5f;
             direction[2] = transform.position.x;
             direction[3] = transform.position.x + 5f;
             direction[4] = transform.position.x + 10f;

             //instantiate an enemy bull
             for (int i = 0; i < 5; i++)
             {
                 directions[i] = new Vector2(direction[i], transform.position.y - 50f);
                 GameObject bullet = (GameObject)Instantiate(Yeh, transform.position, Quaternion.identity);
                 bullet.GetComponent<EB>().SetDirection(directions[i]);

             }*/
            GameObject bullet = (GameObject)Instantiate(Yeh, transform.position, Quaternion.identity);
            bullet.GetComponent<EB>().SetDirection(directions + offset);


        }

    }




}

