using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {
    public int Scene;
    public int count;
    // Use this for initialization
    void Start () {
        count = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (count > 15)
        {
           
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "PlayerBullet")
        {
            count++;
            Debug.Log("Kena");
        }
    }
}
