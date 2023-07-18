using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateFruits : MonoBehaviour
{
    public GameObject[] fruitsPrefabs;
    private GameObject fruit, newFruit;
    
    private void Start()
    {
        newFruit = RandomFruit();
    }

    private void Update()
    {
        if (newFruit.transform.position.z <= 17f)
        {
            CreateFruit();
        }
        else if (newFruit  !=  null && newFruit.transform.position.z <= 17f)
        {
            CreateFruit();
        }
    }
    
    private void CreateFruit()
    {
        newFruit = Instantiate(RandomFruit(), new Vector3(0f, 4.20f, 23f), Quaternion.identity);
    }
    

    private GameObject RandomFruit()
    {
        int random = Random.Range(0, 3);
            
        switch (random)
        {
            case 0 :
                fruit = fruitsPrefabs[0];
                break;
            case 1 :
                fruit = fruitsPrefabs[1];
                break;
            case 2 :
                fruit = fruitsPrefabs[2];
                break;
            default :
                fruit = fruitsPrefabs[0];
                break;
        }
        return fruit;
    }
}
