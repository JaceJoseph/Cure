using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Vector3 Pos;
    public GameObject p;
    bool keluar = true;
    public GameManager game;
    // Use this for initialization
    void Start()
    {
        //pake mathf.clamp mer wkwkwk nih

    }

    // Update is called once per frame
    void Update()
    {
        Pos = transform.position;
        Pos.y = Mathf.Clamp(Pos.y, -9.91f, 20.6f);
        transform.position = Pos;
        transform.Translate(0, -1 * Time.deltaTime, 0);
        if (Pos.y == -9.91f)
        {
            if (keluar && game.bossSpawnActive)
            {
                SpawnEnemy();
            }

        }
    }

        void SpawnEnemy()
        {
            if (keluar)
            {
                Debug.Log("Monster Keluar");
                Instantiate(p, new Vector3(0f, 5f, -6f), Quaternion.identity);
                keluar = false;
            }


        }

}
