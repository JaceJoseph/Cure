using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMTurning : MonoBehaviour {

    public GameObject ExplosionG;
    public GameObject target;
    public float moveSpeed;
    public float rotationSpeed;
    public float count = 0;
    public enemyHealthBarScript healthBar;
    // Use this for initialization
    void Start () {
        healthBar = GetComponentInChildren<enemyHealthBarScript>();

    }
	
	// Update is called once per frame
	void Update () {
        if (count >= 10)
        {
            PlayExplosion();
            Destroy(gameObject);
        }
        if (GameObject.Find("Player")==null)
        {
            PlayExplosion();
            Destroy(gameObject);
        }
        target = GameObject.Find("Player");
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);

        } catch (NullReferenceException e)
        {
            
        }

	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "PlayerBullet")
        {
            healthBar.health -= 0.0801f;
            count++;
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionG);
        explosion.transform.position = transform.position;
    }

}
