using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 pos = player.transform.position;

        if ((transform.position.x <= 15f && transform.position.x >= -15f) && (transform.position.y <= 11f && transform.position.y >= -11f))
        {
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

            transform.position = new Vector3(pos.x, pos.y, -10f);
        }
	}
}
