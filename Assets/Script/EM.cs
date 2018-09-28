 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EM : MonoBehaviour {

    public GameObject ExplosionG;

    float speed;
    public float count = 0;
    public int Scene;
    public enemyHealthBarScript healthBar;

	// Use this for initialization
	void Start () {
        healthBar = GetComponentInChildren<enemyHealthBarScript>();
        speed = 1.5f;
        count = 0;
        Scene = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
        if(count >= 6)
        {
            if (Scene == 1)
            {
                GameManagerv2.CountWin++;
                Debug.Log(GameManagerv2.CountWin);
            }
            PlayExplosion();
            Destroy(gameObject);
        }
        if (GameObject.Find("Player") == null)
        {
            PlayExplosion();
            Destroy(gameObject);
        }
        //Get Enemy Cur pos
        Vector2 position = transform.position;

        //compute the enemey new pos
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update the enemy pos
        transform.position = position;

        //this is the bottom left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //if enemy went outside the screen on bottom - destroyed
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" || col.tag == "PlayerBullet" )
        {
            healthBar.health -= 0.1501f;
            count++;
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionG);
        explosion.transform.position = transform.position;
    }
}
