﻿using UnityEngine;
using System.Collections;

public class StepCreate : MonoBehaviour
{

    public GameObject[] Prefab;
    int roop = -4;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= roop)
        {
            int i = Random.Range(0, 3);
            Instantiate(Prefab[i], new Vector3(gameObject.transform.position.x + 18, 0, 0), Quaternion.identity);           
            roop = roop + 14;
        }
    }
}