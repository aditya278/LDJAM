using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    public int food = 1;
    public int coin = 0;
    int count = 5;
    public float playerSpeed = 2f;
    public float diffSpeed = 0.2f;
    public GameObject[] enemies;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<AIPath>().enabled = false;
            
        }
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Coin" + coin + "food" + food);

        if(food>5)
        {
            for(int i = enemies.Length-1; i>=0;i--)
            {
                if(enemies[i].gameObject.tag == "Bact1")
                {
                    enemies[i].GetComponent<AIPath>().enabled = true;
                    enemies[i].GetComponent<Animator>().SetBool("transform", true);
                }
            }
        } else
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact1")
                {
                    enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                }
            }
        }

        if (food > 4)
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact2")
                {

                    enemies[i].GetComponent<AIPath>().enabled = true;
                    enemies[i].GetComponent<Animator>().SetBool("transform", true);
                }
            }
        }
        else
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact2")
                {

                    enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                }
            }
        }

        if (food > 3)
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact3")
                {
                    enemies[i].GetComponent<AIPath>().enabled = true;
                    enemies[i].GetComponent<Animator>().SetBool("transform", true);
                }
            }
        }
        else
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact3")
                {
                    enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                }
            }

        }

        if (food > 2)
        {
            for (int i = enemies.Length-1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact4")
                {
                    enemies[i].GetComponent<AIPath>().enabled = true;
                    enemies[i].GetComponent<Animator>().SetBool("transform", true);
                }
            }
        }
        else
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact4")
                {
                    enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                   
                }
            }
        }
    }

    public void Increase(int c, int f)
    {
        coin += c;
        food += f;
        playerSpeed -= diffSpeed;
    }

    public void Decrease(int c, int f)
    {
        if (coin - c >= 0)
        {

           

            if (food - f >= 0)
            {
                coin -= c;
                food -= f;
                playerSpeed += diffSpeed;
                
            }
            else
            {
                Debug.Log("Death By Pooping");
               
            }
        }
        else
        {
            Debug.Log("Low on COin");
        }
    }

    public void unFreeze()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
           

        }
    }

    public void Freeze()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

   
}
