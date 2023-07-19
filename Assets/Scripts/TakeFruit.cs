using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TakeFruit : MonoBehaviour
{
    [SerializeField]
    private TaskGeneration taskGeneration;
    [SerializeField] 
    private LevelPassed levelPassed;
    [SerializeField] 
    private GameObject pointBascetDrop;
    [SerializeField]
    private Animator animator;
    [SerializeField] 
    private GameObject fruitPoint;
    [SerializeField]
    private GameObject bascet;
    [SerializeField] 
    private TMP_Text plusOne;
    [SerializeField]
    private Animation animation;
    
    private GameObject _currentFruit;
    private bool _canTake;
    
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Take", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_canTake && other.CompareTag("Fruits"))
        {
            _currentFruit = other.gameObject;
            _currentFruit.transform.localScale = new Vector3(15f,15f,15f);
            _currentFruit.GetComponent<Rigidbody>().isKinematic = true;
            _currentFruit.transform.parent = transform;
            _currentFruit.transform.localPosition = Vector3.zero;
            _currentFruit.transform.localRotation = Quaternion.identity;
            _canTake = true;
        }
        
        if (other.CompareTag("Basket"))
        {
            if (_canTake )
            {
                if (taskGeneration.fruit == _currentFruit.GetComponent<FruitComponent>().Fruit)
                {
                    plusOne.gameObject.SetActive(true);
                    animation.Play();
                    StartCoroutine(StopAnimation());
                    taskGeneration.collectedFruits++;
                    taskGeneration.collected.text = "Collected "+ taskGeneration.collectedFruits;
                    if (taskGeneration.collectedFruits == taskGeneration.randomFruit)
                    {
                        bascet.GetComponent<Rigidbody>().isKinematic = false;
                        bascet.transform.position = pointBascetDrop.transform.position;

                        bascet.transform.SetParent(null);
                        taskGeneration.collected.gameObject.SetActive(false);
                        taskGeneration.collectFruits.gameObject.SetActive(false);
                        levelPassed.RemoveConveyor();
                        
                        animator.SetBool("Dance", true);
                    }
                }
                _currentFruit.transform.parent = bascet.transform;
                _currentFruit.transform.position = fruitPoint.transform.position ;
                _currentFruit.GetComponent<Rigidbody>().isKinematic = false;
                _canTake = false;
                _currentFruit = null;
                _canTake = false;
            }
            animator.SetBool("Take", false);
        }
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1f);
        animation.Stop();
        plusOne.gameObject.SetActive(false);
    }
}
