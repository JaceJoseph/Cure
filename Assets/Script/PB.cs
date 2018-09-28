using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB : MonoBehaviour {

    float speed;

	// Use this for initialization
	void Start () {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        //Bullet Current Pos
        Vector2 position = transform.position;
        
        //compute the bullet new pos
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update bullet pos
        transform.position = position;

        //this is the top right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Bullet Destory out of screen
        if (transform.position.y > max.y) {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBody" || col.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
