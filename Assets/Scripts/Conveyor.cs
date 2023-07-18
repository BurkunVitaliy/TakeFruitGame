using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private Rigidbody rb; 
    public float speed , speedMaterial;
    public Material material;

   private void Start()
   {
       rb = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
    {
        material.mainTextureOffset = new Vector2(Time.time * speedMaterial * Time.deltaTime,0f);
        Vector3 position = rb.position;
        rb.position += Vector3.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }
}
