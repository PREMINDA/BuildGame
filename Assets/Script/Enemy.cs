using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private Transform transformHq;
    private Transform targetTransform;
    private Rigidbody2D rigidbody2d;
    private float speed = 6f;

    private float maxTime = 0.2f;
    private float timer;

    public static Enemy Create(Vector3 position)
    {
        Transform pfEnemy = Resources.Load<Transform>("pfEnemy");
        Transform enemytransform = Instantiate(pfEnemy,position,Quaternion.identity);

        Enemy enemy = enemytransform.GetComponent<Enemy>();
        return enemy;
    }
      
 
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        targetTransform = transformHq;
        timer = maxTime;
    }

    void Update()
    {

        handleMovement();
        handletarget();

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
                
                if (targetTransform == null)
                {
                    targetTransform = buildings.transform;
                }
                else
                {
                    if (Vector3.Distance(transform.position, buildings.transform.position)
                        < Vector3.Distance(transform.position, transformHq.position))
                    {
                        targetTransform = buildings.transform;

                    }
                }
                
            }
        }
    }
    private void handleMovement()
    {
        Vector3 ang = Vector3.zero;
        if (targetTransform != null)
        {
            ang = (targetTransform.position - transform.position).normalized;
        }
        else
        {
            targetTransform = transformHq;
        }

        rigidbody2d.velocity = ang * speed;
        LookForNewTarget();

    }
    private void handletarget()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = maxTime;
            LookForNewTarget();
        }
    }
}
