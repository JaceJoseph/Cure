using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnnerBosss3 : MonoBehaviour
{
    Vector3 Pos;
    float[] direction = new float[2];
    Vector2[] directions = new Vector2[2];
    float count = 0;
    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 151)
        {
            Debug.Log("Win");
            GameObject.Find("GameManagerGO").GetComponent<GameManajerv3>().SetGameManagerState(GameManajerv3.GameManagerState.Victory);
            Destroy(this.gameObject);
        }
        Pos = transform.position;
        Pos.y = Mathf.Clamp(Pos.y, 3f, 5f);
        transform.position = Pos;
        transform.Translate(0, -1f * Time.deltaTime, 0);


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "PlayerBullet")
        {
            count++;
        }
    }
}
