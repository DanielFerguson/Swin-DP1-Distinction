using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    public GameObject food;
    public float spawnSpeed;

    private void Start()
    {
        InvokeRepeating("Generate", 0, spawnSpeed);
    }

    void Generate()
    {
        // Generate random location for food
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        // Create food GameObject
        Instantiate(food, Target, Quaternion.identity);
    }
}
