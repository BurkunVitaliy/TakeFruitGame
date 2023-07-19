using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private Material material;
    
    private Rigidbody _rigidbody; 
    public float speed , speedMaterial;

    private void Start()
   {
       _rigidbody = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
    {
        material.mainTextureOffset = new Vector2(Time.time * speedMaterial * Time.deltaTime,0f);
        Vector3 position = _rigidbody.position;
        _rigidbody.position += Vector3.forward * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position);
    }
}
