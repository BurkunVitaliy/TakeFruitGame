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
    public Fruits fruit;
    public  int collectedFruits, randomFruit;
    
    private string _fruitText;
    
   
    private void Start()
    {
        randomFruit = RandomNumber();
        collectFruits.text +=  "Collect " + randomFruit + " " + RandomFruit();
        collected.text = "Collected 0" ;
    }
    
    public int RandomNumber()
    {
        int random = Random.Range(1, 6);
        return random;
    }
    
    public string RandomFruit()
    {
        int random = Random.Range(0, 3);
            
        switch (random)
        {
            case 0 :
                _fruitText = "Apples";
                fruit = Fruits.Apple;
                break;
            case 1 :
                _fruitText = "Bananas";
                fruit = Fruits.Banana;
                break;
            case 2 :
                _fruitText = "Lemons";
                fruit = Fruits.Lemon;
                break;
            default :
                _fruitText = "Apples";
                fruit = Fruits.Apple;
                break;
        }
        return _fruitText;
    }
}
