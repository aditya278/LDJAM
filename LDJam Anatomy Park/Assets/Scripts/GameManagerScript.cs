using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {


    public int food = 1;
    public int coin = 0;
    public float playerSpeed = 2f;
    public float diffSpeed = 0.2f;
    public GameObject[] enemies;
    PlayerMovement playerMovement;
    public GameObject ftext,ctext;

    public int life = 5;

    public GameObject gameOverCanvas;
    public GameObject gameWonCanvas;

    public GameObject gameUI;
    public Animator gameUiAnim;
    int x = 0;

	// Use this for initialization
	void Start () {

        playerMovement = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>();
        //for (int i = 0; i < enemies.Length; i++)
        //{
            //enemies[i].GetComponent<AIPath>().enabled = false;
            
        //}
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("Coin" + coin + "food" + food);

        ftext.GetComponent<Text>().text = "Food: " + food;

        ctext.GetComponent<Text>().text = "Coin: " + coin;

        if (food>5)
        {
            for(int i = enemies.Length-1; i>=0;i--)
            {
                if(enemies[i].gameObject.tag == "Bact1" && !playerMovement.insideToilet && !playerMovement.insideCoster && !playerMovement.insideKidney && !playerMovement.insideMirror)
                {
                    enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
                    Freeze();
                    //enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                }
            }
        }

        if (food > 4)
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact2" && !playerMovement.insideToilet && !playerMovement.insideCoster && !playerMovement.insideKidney && !playerMovement.insideMirror)
                {
                    enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
                    Freeze();
                   // enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                }
            }
        }

        if (food > 3)
        {
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact3" && !playerMovement.insideToilet && !playerMovement.insideCoster && !playerMovement.insideKidney && !playerMovement.insideMirror)
                {
                    enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
                    Freeze();
                   // enemies[i].GetComponent<AIPath>().enabled = false;
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                }
            }

        }

        if (food > 2)
        {
            for (int i = enemies.Length-1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact4" && !playerMovement.insideToilet && !playerMovement.insideCoster && !playerMovement.insideKidney && !playerMovement.insideMirror)
                {
                    enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
                    // enemies[i].GetComponent<AIPath>().enabled = false;
                    Freeze();
                    enemies[i].GetComponent<Animator>().SetBool("transform", false);
                   

                }
            }
        }

        if (PlayerPrefs.GetInt("firsttime", 1) == 2)
        {
            gameUI.gameObject.SetActive(false);
        }
        if(Input.GetMouseButtonDown(0) && PlayerPrefs.GetInt("firsttime",1)==1)
        {
            x++;
            gameUiAnim.SetInteger(Animator.StringToHash("xDist"),x);
            
            if (x>3)
            {
                gameUI.gameObject.SetActive(false);
                PlayerPrefs.SetInt("firsttime", 2);
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
                GameOver();
               
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

    public void ReduceLife(int n)
    {
        if(life-n >= 0)
            life -= n;
        else
        {
            GameOver();
        }
    }

    public void EnterRides(int c, int rideNo)
    {
        if(coin - c >= 0)
        {
            Freeze();
            coin -= c;

            if(rideNo == 0)
            {
                playerMovement.ridedKidney = true;
            } else if (rideNo == 1)
            {
                playerMovement.ridedMirror = true;
            } else
            {
                playerMovement.ridedCoster = true;
            }

        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);

    }
   
    public void Won()
    {
        Time.timeScale = 0;
        gameWonCanvas.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Main Scene");
        gameOverCanvas.SetActive(false);
        gameWonCanvas.SetActive(false);
        gameUI.SetActive(false);
        Time.timeScale = 1;
    }
}
