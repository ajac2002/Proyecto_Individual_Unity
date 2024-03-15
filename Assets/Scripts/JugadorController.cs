using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEditor.Experimental.GraphView;

public class JugadorController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public GameManager myGameManager;
    public Sprite[] mySprites;
    //private int index = 0;
    //private bool Grounded;

    private Rigidbody2D myrigidbody2D;
    public GameObject Bullet;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(WalkCoRutine());
        myGameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        //if (Physics2D.Raycast(transform.position,Vector3.down,0.1f))
        //{
        //    Grounded = true;
        //}
        //else Grounded = false;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        
    }

    //IEnumerator WalkCoRutine()
    //{
    //    yield return new WaitForSeconds(0.05f);
    //    mySpriteRenderer.sprite = mySprites[index];
    //    index++;
    //    if (index == 6)
    //    {
    //        index = 0;
    //    }
    //    StartCoroutine(WalkCoRutine());
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }


    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
