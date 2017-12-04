using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriigger : MonoBehaviour {

	public Animator boxAnim;
    GameManagerScript gameManager;
	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("Gamemanager").gameObject.GetComponent<GameManagerScript>();
		boxAnim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	public void trigger()
	{
	
		bool open = boxAnim.GetBool("isOpen");

		if (!open)
		{
			boxAnim.SetBool("isOpen", true);
            gameManager.Increase(1,1);

		}
		/*else
		{
			boxAnim.SetBool("isOpen", false);
		}*/
	}
}
