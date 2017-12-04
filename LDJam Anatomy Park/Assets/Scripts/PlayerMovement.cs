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

        } else if (dirY < 0 || dirX != 0)
        {
            anim.SetBool("moveDown", true);
            anim.SetBool("moveUp", false);
            anim.SetBool("isIdle", false);

        } else
        {
            anim.SetBool("moveDown", false);
            anim.SetBool("moveUp", false);
            anim.SetBool("isIdle", true);
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
		transform.Translate(new Vector2(dirX * speed * Time.deltaTime, dirY * speed * Time.deltaTime));


        if(collidedWithBox && Input.GetMouseButtonDown(0))
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

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "box")
        {
            collidedWithBox = true;
			boxxgam = collision.gameObject;
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
        if(collision.gameObject.tag == "Toilet")
        {
            
            gameManager.Decrease(1,1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Toilet")
        {
            gameManager.unFreeze();
        }
    }

}
