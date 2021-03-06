﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour {

    [Header("Map")]
    public GameObject SpawnArea;

    [Header("Token Prefabs")]
    public GameObject UnitCredit;
    public GameObject JobApplication;

    [Header("Token Settings")]
    public float creditSpawnSpeed = 5f;
    public float jobSpawnSpeed = 1.5f;

    private float mapHeight = 0f;
    private float mapWidth = 0f;


    private void Start()
    {
        // Get Map dimentions
        mapHeight = SpawnArea.GetComponent<RectTransform>().rect.height;
        mapWidth = SpawnArea.GetComponent<RectTransform>().rect.width;
        
        // Invoke asset creation
        InvokeRepeating("GenerateUnitCredits", 0, creditSpawnSpeed);
        InvokeRepeating("GenerateJobApplications", 0, creditSpawnSpeed);
    }

    private Vector3 GenerateRandomLocation()
    {
        int x = Random.Range(-(Mathf.RoundToInt(mapWidth) / 2), Mathf.RoundToInt(mapWidth) / 2);
        int y = Random.Range(-(Mathf.RoundToInt(mapHeight) / 2), Mathf.RoundToInt(mapHeight) / 2);

        return new Vector3(x, y, 0);
    }
    void GenerateUnitCredits()
    {
        Instantiate(UnitCredit, GenerateRandomLocation(), Quaternion.identity);
    }
    void GenerateJobApplications()
    {
        Instantiate(JobApplication, GenerateRandomLocation(), Quaternion.identity);
    }
}
