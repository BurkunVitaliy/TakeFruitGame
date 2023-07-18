using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TakeFruit : MonoBehaviour
{
    private GameObject currentFruit;
    private bool canTake;
    public Animator Animator;
    public GameObject fruitPoint, bascet;
    public TMP_Text plusOne;
    public Animation _animation;
    [SerializeField]
    private TaskGeneration _taskGeneration;
    [SerializeField] 
    private LevelPassed _levelPassed;
    [SerializeField] 
    private GameObject pointBascetDrop;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Animator.SetBool("Take", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canTake && other.CompareTag("Fruits"))
        {
            currentFruit = other.gameObject;
            currentFruit.transform.localScale = new Vector3(15f,15f,15f);
            currentFruit.GetComponent<Rigidbody>().isKinematic = true;
            currentFruit.transform.parent = transform;
            currentFruit.transform.localPosition = Vector3.zero;
            currentFruit.transform.localRotation = Quaternion.identity;
            canTake = true;
        }
        
        if (other.CompareTag("Basket"))
        {
            if (canTake )
            {
                if (_taskGeneration._fruit == currentFruit.GetComponent<FruitComponent>().Fruit)
                {
                    plusOne.gameObject.SetActive(true);
                    _animation.Play();
                    StartCoroutine(StopAnimation());
                    _taskGeneration.collectedFruits++;
                    _taskGeneration.collected.text = "Collected "+ _taskGeneration.collectedFruits;
                    if (_taskGeneration.collectedFruits == _taskGeneration.randomFruit)
                    {
                        bascet.GetComponent<Rigidbody>().isKinematic = false;
                        bascet.transform.position = pointBascetDrop.transform.position;

                        bascet.transform.SetParent(null);
                        _taskGeneration.collected.gameObject.SetActive(false);
                        _taskGeneration.collectFruits.gameObject.SetActive(false);
                        _levelPassed.RemoveConveyor();
                        
                        Animator.SetBool("Dance", true);
                    }
                }
                currentFruit.transform.parent = bascet.transform;
                currentFruit.transform.position = fruitPoint.transform.position ;
                currentFruit.GetComponent<Rigidbody>().isKinematic = false;
                canTake = false;
                currentFruit = null;
                canTake = false;
            }
            Animator.SetBool("Take", false);
        }
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1f);
        _animation.Stop();
        plusOne.gameObject.SetActive(false);
    }
}
