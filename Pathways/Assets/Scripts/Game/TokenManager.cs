using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour {

    [Header("Token Prefabs")]
    public GameObject UnitCredit;
    public GameObject JobApplication;

    [Header("Token Settings")]
    public float creditSpawnSpeed = 5f;
    public float jobSpawnSpeed = 3f;

    private void Start()
    {
        InvokeRepeating("GenerateUnitCredits", 0, creditSpawnSpeed);
        InvokeRepeating("GenerateJobApplications", 0, creditSpawnSpeed);
    }

    void GenerateUnitCredits()
    {
        // Generate random location for Unit Credits
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        // Create UnitCredit GameObject
        Instantiate(UnitCredit, Target, Quaternion.identity);
    }
    void GenerateJobApplications()
    {
        // Generate random location for Job Applications
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        // Create JobApplication GameObject
        Instantiate(JobApplication, Target, Quaternion.identity);
    }
}
