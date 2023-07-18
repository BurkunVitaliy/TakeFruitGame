using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFruit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruits"))
        {
            Destroy(other.gameObject);
        }
    }
}
