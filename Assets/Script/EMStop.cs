using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMStop : MonoBehaviour
{

    float speed;
    public float count = 0;

    // Use this for initialization
    void Start()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            Destroy(gameObject);
        }
        if (GameObject.Find("Player") == null)
        {
            Destroy(gameObject);
        }
        //Get Enemy Cur pos
        Vector2 position = transform.position;
        
        //compute the enemey new pos
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update the enemy pos
        transform.position = position;

        //this is the bottom left point of the screen
        Vector2 min = new Vector2(0, 3.51f);

        transform.Translate(0, -1f * Time.deltaTime, 0);

        //if enemy went outside the screen on bottom - destroyed
        if (transform.position.y < min.y)
        {
            speed = 0f;
            position.y = 3.51f;
            transform.position = position;
            
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

