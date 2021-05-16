﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private Transform transformHq;
    private Rigidbody2D rigidbody2d;
    private float speed = 6f;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 ang = (transformHq.position - transform.position).normalized;
        rigidbody2d.velocity = ang * speed;
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
}