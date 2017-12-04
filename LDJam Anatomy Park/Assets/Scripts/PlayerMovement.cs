using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    Animator anim;
    //public Animator boxAnim;
    float xScale;
    float yScale;
    public bool collidedWithBox;
	GameObject boxxgam;
    public GameManagerScript gameManager;
    public bool insideToilet = false;
    public bool insideKidney = false;
    public bool insideCoster = false;
    public bool insideMirror = false;

    public bool ridedKidney = false;
    public bool ridedCoster = false;
    public bool ridedMirror = false;

    public GameObject exitGate;

    public AudioSource hurt;
    public AudioSource flush;
    public AudioSource rides;

    public bool isHurt = false;

    // Use this for initialization
    void Start () {

        gameManager = GameObject.FindGameObjectWithTag("Gamemanager").gameObject.GetComponent<GameManagerScript>();
        speed = gameManager.playerSpeed;
        anim = GetComponent<Animator>();
        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
        collidedWithBox = false;
	}
	
	// Update is called once per frame
	void Update () {

        speed = gameManager.playerSpeed;
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        
        if(dirX < 0)
        {
            transform.localScale = new Vector2(-xScale, yScale);
        } else
        {
            transform.localScale = new Vector2(xScale, yScale);
        }

        if (dirY > 0)
        {
            anim.SetBool("moveDown", false);
            anim.SetBool("moveUp", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("hurtMoveUp", false);
            anim.SetBool("hurtIdle", false);

        } else if (dirY < 0 || dirX != 0)
        {
            anim.SetBool("moveDown", true);
            anim.SetBool("moveUp", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("hurtMoveUp", false);
            anim.SetBool("hurtIdle", false);

        } else
        {
            anim.SetBool("moveDown", false);
            anim.SetBool("moveUp", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("hurtMoveUp", false);
            anim.SetBool("hurtIdle", false);
        }


        if (gameManager.food >= 4)
        {
            isHurt = true;
            if (dirY > 0)
            {
                anim.SetBool("moveDown", false);
                anim.SetBool("hurtMoveUp", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("hurtIdle", false);
                anim.SetBool("moveUp", false);
            }
            else if (dirY < 0 || dirX != 0)
            {
                anim.SetBool("moveDown", true);
                anim.SetBool("moveUp", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("hurtMoveUp", false);
                anim.SetBool("hurtIdle", false);

            }
            else
            {
                anim.SetBool("moveDown", false);
                anim.SetBool("moveUp", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("hurtMoveUp", false);
                anim.SetBool("hurtIdle", true);

            }
        }


        //using direct values of dirx nd y was not feasible
        /*	if (dirX < 0) {
                dirX = -1;
            }
            if (dirX > 0) {
                dirX = 1;
            }
            if (dirY > 0) {
                dirY = 1;
            }
            if (dirY < 0) {
                dirY = -1;
            }*/
        //if((transform.position.x+dirX <= 18f && transform.position.x+dirX >= -18f) && (transform.position.y+dirY <= 13f && transform.position.y+dirY >= -13f)  )
        //transform.Translate(new Vector2(dirX * speed * Time.deltaTime, dirY * speed * Time.deltaTime));
        transform.position += new Vector3(dirX * speed * Time.deltaTime, dirY * speed * Time.deltaTime);

        if (collidedWithBox && Input.GetMouseButtonDown(0))
        {
           
			BoxTriigger b = boxxgam.GetComponent<BoxTriigger> ();
			b.trigger ();

			/*bool open = boxAnim.GetBool("isOpen");

            if (!open)
            {
                boxAnim.SetBool("isOpen", true);
            }
            else
            {
                boxAnim.SetBool("isOpen", false);
            }*/
        }

        if (insideToilet && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Entered Toilet");
            flush.Play();
            gameManager.Decrease(1, 1);
        }


        if (insideKidney && Input.GetMouseButtonDown(0) && !ridedKidney)
        {
            Debug.Log("Entered Kidney");
            rides.Play();
            gameManager.EnterRides(1, 0);
           
            
        }

        if (insideMirror && Input.GetMouseButtonDown(0) && !ridedMirror)
        {
            Debug.Log("Entered Mirror");
            rides.Play();
            gameManager.EnterRides(1, 1);
           
        }

        if (insideCoster && Input.GetMouseButtonDown(0) && !ridedCoster)
        {
            Debug.Log("Entered Coster");
            rides.Play();
            gameManager.EnterRides(1, 2);
            
        }
        if (ridedCoster && ridedKidney && ridedMirror)
        {
            exitGate.SetActive(false);
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "box")
        {
            collidedWithBox = true;
			boxxgam = collision.gameObject;
        }

        if (collision.gameObject.tag == "Bact1" || collision.gameObject.tag == "Bact2" || collision.gameObject.tag == "Bact3" || collision.gameObject.tag == "Bact4")
        {
            hurt.Play();
            gameManager.GameOver();
            //transform.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.gameObject.GetComponent<Collider>().GetComponent<Rigidbody2D>().transform.forward * 5f, ForceMode2D.Impulse);
        }


    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            collidedWithBox = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.gameObject.tag == "Won")
        {
            gameManager.Won();
        }

        if (collision.gameObject.tag == "Toilet")
        {
            insideToilet = true;
            gameManager.Freeze();
        }

        if(collision.gameObject.tag == "Kidney")
        {
            insideKidney = true;
            gameManager.Freeze();
        }

        if(collision.gameObject.tag == "Mirror")
        {
            insideMirror = true;
            gameManager.Freeze();
        }

        if(collision.gameObject.tag == "Coster")
        {
            insideCoster = true;
            gameManager.Freeze();
        }

        if(collision.gameObject.tag == "Toxic")
        {
            hurt.Play();
            gameManager.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Toilet")
        {
            insideToilet = false;
            Debug.Log("Exited Toilet");
            gameManager.unFreeze();
        }

        if (collision.gameObject.tag == "Kidney")
        {
            insideKidney = false;
            gameManager.unFreeze();
        }

        if (collision.gameObject.tag == "Mirror")
        {
            insideMirror = false;
            gameManager.unFreeze();
        }

        if (collision.gameObject.tag == "Coster")
        {
            insideCoster = false;
            gameManager.unFreeze();
        }

    }

}
