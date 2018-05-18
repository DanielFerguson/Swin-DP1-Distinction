using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") {
            Debug.Log("enemy collision");
            
            Destroy(other.gameObject);

            //    col.gameObject.velocity = col.gameObject.velocity * -1;
        }
    }
}
