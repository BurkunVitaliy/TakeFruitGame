using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TaskGeneration : MonoBehaviour
{
    public TMP_Text collectFruits;
    public TMP_Text collected;
    private string fruit;
    public Fruits _fruit;
    public  int collectedFruits, randomFruit;
    
   
    private void Start()
    {
        randomFruit = RandomNumber();
        collectFruits.text +=  "Collect " + randomFruit + " " + RandomFruit();
        collected.text = "Collected 0" ;
    }
    
    public int RandomNumber()
    {
        int random = Random.Range(1, 5);
        return random;
    }
    
    public string RandomFruit()
    {
        int random = Random.Range(0, 3);
            
        switch (random)
        {
            case 0 :
                fruit = "Apples";
                _fruit = Fruits.Apple;
                break;
            case 1 :
                fruit = "Bananas";
                _fruit = Fruits.Banana;
                break;
            case 2 :
                fruit = "Lemons";
                _fruit = Fruits.Lemon;
                break;
            default :
                fruit = "Apples";
                _fruit = Fruits.Apple;
                break;
        }
        return fruit;
    }
}
