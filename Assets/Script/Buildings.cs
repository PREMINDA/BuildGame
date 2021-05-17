using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private BuildingTypeso buildingTypeso;
    private HealthSystem healthSystem;


    private void Awake()
    {
 
    }


    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDide += HealthSystem_OnDide;
    }

    private void HealthSystem_OnDide(object sender, System.EventArgs e)
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            healthSystem.Damage(10);
        }
    }
    

}
