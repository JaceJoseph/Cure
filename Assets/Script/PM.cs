using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PM : MonoBehaviour
{
    public GameObject ExplosionG;
    public GameObject GameManagerGO;
    public GameObject Bullet;
    public GameObject[] PlayerBulletGo;
    public GameObject Hey;
    public float maxWidth;
    public float maxHeight;
    public float speed;
    public float delay;
    public Rigidbody2D rb;
    public Camera camera;
	public int weapon;
    public Vector2 direction;
    public Vector2 pos;
    public Text LivesUIText;
    const int MaxLives = 5;
    public 	int lives; 
    Vector2 StartPos;
    Vector2 Direction;

    public void init()
    {
        lives = MaxLives;
		LivesUIText.text = lives.ToString();
        gameObject.SetActive(true);
        StartCoroutine(AttackMechanism(delay));
		Debug.Log("a");
    }
    public void Awake()
    {

        StartCoroutine(AttackMechanism(delay));
    }

    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        Vector2 screenTarget = new Vector2(Screen.width, Screen.height);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
        StartCoroutine(AttackMechanism(delay));
    }

    // Update is called once per frame
    void Update () {

        
        //when pressed spacebar bullet shot
        if (Input.GetKeyDown(KeyCode.M))
        {
			
        }
        
        float x = Input.GetAxisRaw ("Horizontal"); //The value willve -1,0,1 (for Left, No Input, and Right)
        float y = Input.GetAxisRaw ("Vertical");//The value willve -1,0,1 (for down, No Input, and up)

        //based on the input, we compute a direction vector, and we normalize it to get a unit vector
        direction = new Vector2(x, y).normalized;
        
        //now we call the function that computes and sets the player position
		Move ();
        Move(direction);
    }

	public void SwapWeapon(){
		weapon++;
		if (weapon > 1) {
			weapon = 0;
		}
	}

    void Move()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
             

        } else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Direction = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position = Direction;
        }

    }

    void Move (Vector2 direction)
    {
        //Screen limits
        Vector2 min = Camera.main.ScreenToWorldPoint (new Vector2 (0,0)); //Bottom Left
        Vector2 max = Camera.main.ScreenToWorldPoint (new Vector2 (1,1)); //Top Right
       

        /*max.x = max.x - 0.225f; //substract the player sprite half width
        min.x = min.x + 0.225f; //add the player sprite half width

        max.y = max.y - 0.285f; //substract the player sprite half height
        min.y = min.y + 0.285f; //add the player sprite half height*/
        
        //buat gerak
        rb.velocity = direction * speed * Time.deltaTime;
        
        //buat batasin
        pos = rb.transform.position;

        pos.x = Mathf.Clamp(pos.x, -2.7f, 2.7f);
        pos.y = Mathf.Clamp(pos.y, -4.4f, 4.6f);

        rb.transform.position = pos;

        Vector3 akux = camera.transform.position;
        akux.x = Mathf.Clamp(akux.x, -3f, 3f);
        akux.y = Mathf.Clamp(akux.y, -3.5f , 3.75f);
        camera.transform.position = akux;

        /*float distanceX = transform.position.x - camera.transform.position.x;
        float distanceY = transform.position.y - camera.transform.position.y;

        if (distanceX > 2.5f)
        {
            camera.transform.Translate(0.1f, 0f, 0f);
        }
        else if (distanceX < -2.5f)
        {
            camera.transform.Translate(-0.1f, 0f, 0f);
        }
        else if (distanceY < -2.5f)
        {
            camera.transform.Translate(0f, -0.1f, 0f);
        }
        else if (distanceY > 2.5f)
        {
            camera.transform.Translate(0f, 0.1f, 0f);
        }*/
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "EnemyBullet")||(col.tag == "EnemyBody"))
        {
            HealthBarScript.health -= 0.18f;
            lives--;
            LivesUIText.text = lives.ToString();
            if (lives == 0)
            {
                PlayExplosion();
                GameManagerGO.GetComponent<GameManagerv2>().SetGameManagerState(GameManagerv2.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
    }

    public IEnumerator AttackMechanism(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject bullet = Instantiate(PlayerBulletGo[weapon], Hey.transform.position, Quaternion.identity);
        StartCoroutine(AttackMechanism(delay));
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionG);
        explosion.transform.position = transform.position;
    }
}

