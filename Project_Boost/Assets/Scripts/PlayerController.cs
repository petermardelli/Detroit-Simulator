using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody rb;
  AudioSource audioSource;
  [SerializeField]private float thrustForce = 10f;
  [SerializeField]private float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource =GetComponent<AudioSource>();
    }

    
    public void Thrust()
    {
     
          rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
          if(!audioSource.isPlaying) audioSource.Play();
        
    }

    public void RotateLeft()
    {
        ApplyRotation(rotationSpeed);
       
    }
    
    public void RotateRight()
    {
         ApplyRotation(-rotationSpeed);
    }

    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
