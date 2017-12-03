using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2f;
    Animator anim;
    public Animator boxAnim;
    float xScale;
    float yScale;
    public bool collidedWithBox;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
        collidedWithBox = false;
	}
	
	// Update is called once per frame
	void Update () {

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

        transform.Translate(new Vector2(dirX * speed * Time.deltaTime, dirY * speed * Time.deltaTime));


        if(collidedWithBox && Input.GetMouseButtonDown(0))
        {
            bool open = boxAnim.GetBool("isOpen");

            if (!open)
            {
                boxAnim.SetBool("isOpen", true);
            }
            else
            {
                boxAnim.SetBool("isOpen", false);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "box")
        {
            collidedWithBox = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collidedWithBox = false;
    }
}
