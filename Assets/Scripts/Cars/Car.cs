using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool enableMovement = true;
    [SerializeField] private LayerMask mask;
    [SerializeField] private AudioClip honk;
    
    [Header("Car Stopping Distance")]
    [SerializeField] private Vector3 stoppingCenter;
    [SerializeField] private Vector3 stoppingHalfExtents;
    
    private bool isMoving = true;
    private AudioSource audioSource;
    private float honkCooldown = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Prevent cars from colliding with the player and each others
        CheckFrontCollision();
        if (enableMovement && isMoving)
        {
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));    
        }
        else
        {
            if (honkCooldown >= 2f)
            {
                PlayHonkAudio();
                honkCooldown = 0;
            }
            else
            {
                honkCooldown += Time.deltaTime;
            }
        }
    }

    void CheckFrontCollision()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        var collision = Physics.OverlapBox(transform.position + transform.TransformDirection(
            Vector3Mult(stoppingCenter, transform.localScale)), Vector3Mult(stoppingHalfExtents, transform.localScale), 
            Quaternion.identity, mask.value);
        
        isMoving = collision.Length <= 0;
        
        gameObject.layer = LayerMask.NameToLayer("Car");
    }
    
    private void PlayHonkAudio(){
        if (!audioSource)
        {
            return;
        }
        audioSource.PlayOneShot(honk);
    }

    private Vector3 Vector3Mult(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyCar"))
        {
            Destroy(gameObject);
        }
    }

    //To show collision checking box in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = isMoving ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + transform.TransformDirection(Vector3Mult(stoppingCenter, transform.localScale)), Vector3Mult(stoppingHalfExtents, transform.localScale)*2);
    }
}
