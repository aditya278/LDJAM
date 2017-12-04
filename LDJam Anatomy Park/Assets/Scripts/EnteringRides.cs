using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringRides : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Debug.Log("Entered Mirror");
        }
        else if (collision.gameObject.tag == "Kidney")
        {
            Debug.Log("Entered Kidney");
        }
        else if (collision.gameObject.tag == "Coster")
        {
            Debug.Log("Entered Coster");
        }
    }
}
