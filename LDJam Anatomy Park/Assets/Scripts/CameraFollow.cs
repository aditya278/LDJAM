using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		/*float dirX = Input.GetAxis("Horizontal");
		float dirY = Input.GetAxis("Vertical");
		if (dirX < 0) {
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
		}
		if ((pos.x+dirX <= 16f && pos.x+dirX >= -16f) && (pos.y+dirY <= 12f && pos.y+dirY >= -12f)  )
        {*/
            /* if (pos.x < transform.position.x - 5f)
             {
                 transform.position = new Vector3(transform.position.x - 5f, transform.position.y, -10f);
             }
             else if (pos.x > transform.position.x + 5f)
             {
                 transform.position = new Vector3(transform.position.x + 5f, transform.position.y, -10f);
             }
             else if (pos.y < transform.position.y - 5f)
             {
                 transform.position = new Vector3(transform.position.x, transform.position.y - 5f, -10f);
             }
             else if (pos.y > transform.position.y + 5f)
             {
                 transform.position = new Vector3(transform.position.x, transform.position.y + 5f, -10f);
             }
             */

			//Commented it as sometimes when player touch boundary and comes back from different it feels glitchy  
			//transform.position = new Vector3(pos.x, pos.y, -10f);
		
			transform.position = new Vector3 (pos.x, pos.y, -10f);

		//}


	}
}
