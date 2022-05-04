using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField]private float thrustForce = 10f;
  [SerializeField]private float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
         if(Input.GetKey(KeyCode.W))
        {
          rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }
    }

    private void ProcessRotation()
    {
       
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
