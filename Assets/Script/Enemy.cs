using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private Transform transformHq;
    private Transform targetTransform;
    private Rigidbody2D rigidbody2d;
    private float speed = 6f;
 
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        targetTransform = transformHq;
    }

    void Update()
    {
        Vector3 ang = (transformHq.position - transform.position).normalized;
        rigidbody2d.velocity = ang * speed;
        LookForNewTarget();



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Buildings buildings = collision.gameObject.GetComponent<Buildings>();
        if(buildings != null)
        {
            HealthSystem healthSystem = buildings.GetComponent<HealthSystem>();
            healthSystem.Damage(50);
            Destroy(this.gameObject);
        }
        
    }
    private void LookForNewTarget()
    {
        float tartgetMaxRadius = 10f;

        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, tartgetMaxRadius);
        
        foreach(Collider2D collider2d in collider2DArray)
        {
            Buildings buildings = collider2d.GetComponent<Buildings>();
            
            if (buildings != null) {
                Debug.Log("......................." + buildings);
                if (targetTransform == null)
                {
                    targetTransform = buildings.transform;
                }
                else
                {
                    if(Vector3.Distance(transform.position,buildings.transform.position)
                        < Vector3.Distance(transform.position, transformHq.position))
                    {
                        targetTransform = buildings.transform;
                    }
                }
            }
            
        }
    }
}
