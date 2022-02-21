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
    
    [Header("Car Stopping Distance")]
    [SerializeField] private Vector3 stoppingCenter;
    [SerializeField] private Vector3 stoppingHalfExtents;
    
    private bool isMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void CheckFrontCollision()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        var collision = Physics.OverlapBox(transform.position + transform.TransformDirection(Vector3Mult(stoppingCenter, transform.localScale)), Vector3Mult(stoppingHalfExtents, transform.localScale), Quaternion.identity, mask.value);
        
        isMoving = collision.Length <= 0;
        
        gameObject.layer = LayerMask.NameToLayer("Car");
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

    private void OnDrawGizmos()
    {
        Gizmos.color = isMoving ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3Mult(stoppingCenter, transform.localScale), Vector3Mult(stoppingHalfExtents, transform.localScale)*2);
    }
}
