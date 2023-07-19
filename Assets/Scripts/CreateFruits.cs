using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateFruits : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruitsPrefabs;
    
    private GameObject _fruit, _newFruit;
    
    private void Start()
    {
        _newFruit = RandomFruit();
    }

    private void Update()
    {
        if (_newFruit.transform.position.z <= 17f)
        {
            CreateFruit();
        }
        else if (_newFruit  !=  null && _newFruit.transform.position.z <= 17f)
        {
            CreateFruit();
        }
    }
    
    private void CreateFruit()
    {
        _newFruit = Instantiate(RandomFruit(), new Vector3(0f, 4.20f, 23f), Quaternion.identity);
    }
    

    private GameObject RandomFruit()
    {
        int random = Random.Range(0, 3);
            
        switch (random)
        {
            case 0 :
                _fruit = fruitsPrefabs[0];
                break;
            case 1 :
                _fruit = fruitsPrefabs[1];
                break;
            case 2 :
                _fruit = fruitsPrefabs[2];
                break;
            default :
                _fruit = fruitsPrefabs[0];
                break;
        }
        return _fruit;
    }
}
