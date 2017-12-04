using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriigger : MonoBehaviour {

	public Animator boxAnim;
	// Use this for initialization
	void Start () {

		boxAnim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	public void trigger()
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
