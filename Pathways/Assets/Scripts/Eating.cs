using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour {

    public string Tag;
    public Text Letters;

    private int Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            // Destroy GameObject
            Destroy(other.gameObject);

            // Increment Score
            Score += 10;
            Letters.text = "Score: " + Score;
        }
    }
}
