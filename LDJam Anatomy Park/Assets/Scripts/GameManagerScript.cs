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

        if (food > 4)
        {
            for (int i = enemies.Length-1; i >= 0; i--)
            {
                if(enemies[i].gameObject.tag=="Bact1" || enemies[i].gameObject.tag == "Bact2")
                    enemies[i].GetComponent<AIPath>().enabled = true;
            }
        } else if (food > 3)
        {
            for (int i = enemies.Length-1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact3")
                    enemies[i].GetComponent<AIPath>().enabled = true;
            }
        } else if (food > 2)
        {
            for (int i = enemies.Length-1; i >= 0; i--)
            {
                if (enemies[i].gameObject.tag == "Bact4")
                    enemies[i].GetComponent<AIPath>().enabled = true;
            }
        }
    }

    public void Increase(int c, int f)
    {
        coin += c;
        food += f;
        playerSpeed -= diffSpeed;
    }
}
