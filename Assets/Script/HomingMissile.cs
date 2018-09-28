using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

    public Transform target;

    public float speed;
    public float rotateSpeed;
    public float time;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        StartCoroutine(Timer(time));
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }
    
    public IEnumerator Timer(float _Time)
    {
        yield return new WaitForSeconds(_Time);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }

}
